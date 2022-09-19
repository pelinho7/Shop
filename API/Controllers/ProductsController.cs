using API.DTOs;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;
using API.Helpers;
using API.Extensions;
using Microsoft.AspNetCore.Http;
using API.Interfaces;
using API.DBAccess.Interfaces;
using AutoMapper;
using API.DBAccess.Entities;
using Microsoft.AspNetCore.Authorization;

namespace API.Controllers
{
    public class ProductsController : BaseApiController
    {
        private readonly IUnitOfWork unitOfWork;
        private readonly IMapper mapper;
        private readonly ILogger<ProductsController> logger;
        private readonly IPhotoService photoService;

        public ProductsController(IUnitOfWork unitOfWork, IMapper mapper
            , ILogger<ProductsController> logger, IPhotoService photoService)
        {
            this.unitOfWork = unitOfWork;
            this.mapper = mapper;
            this.logger = logger;
            this.photoService = photoService;
        }

        [HttpPost("create-product")]
        public async Task<ActionResult<UpsertProductDto>> CreateProduct()
        {
            Product newProduct = new Product() { Temporary = true, CreateDate = DateTime.UtcNow, ModDate = DateTime.UtcNow };
            unitOfWork.ProductRepository.AddProduct(newProduct);
            var savingResult = await unitOfWork.Complete();

            if (!savingResult) return StatusCode(StatusCodes.Status500InternalServerError, "Saving data incompleted");

            var productDto = mapper.Map<UpsertProductDto>(newProduct);
            return Ok(productDto);
        }

        [HttpPost("update-product")]
        public async Task<ActionResult<UpsertProductDto>> UpdateProduct(UpsertProductDto productDto)
        {
            if (productDto == null) return BadRequest();

            var product = await unitOfWork.ProductRepository.GetProductById(productDto.Id);

            if (product == null) return NotFound();

            using (var transaction = await unitOfWork.BeginTransaction())
            {
                try
                {
                    DateTime modDate = DateTime.UtcNow;
                    var newProduct = mapper.Map<Product>(productDto);
                    newProduct.ModDate = modDate;
                    var updatedProduct = await unitOfWork.ProductRepository.UpdateProduct(newProduct);

                    var savingResult = await unitOfWork.Complete();

                    if (!savingResult) throw new Exception();

                    unitOfWork.ProductHistoryRepository.AddProductHistory(updatedProduct);
                    //if TextAttributes list is null set empty list
                    if (productDto.TextAttributes == null)
                    {
                        productDto.TextAttributes = new List<ProductTextAttributeDto>();
                    }

                    //remove old attributes
                    var textAttributesDeleted = await unitOfWork.ProductTextAttributeRepository
                    .DeleteOldProductTextAttributes(updatedProduct.Id, productDto.TextAttributes.Select(x => x.AttributeId).ToList(), modDate);

                    if (textAttributesDeleted != null && textAttributesDeleted.Any())
                    {
                        textAttributesDeleted.ForEach(a =>
                        {
                            unitOfWork.ProductTextAttributeHistoryRepository.AddProductTextAttributeHistory(a);
                        });

                        savingResult = await unitOfWork.Complete();
                        if (!savingResult) throw new Exception();
                    }

                    //if NumberAttributes list is null set empty list
                    if (productDto.NumberAttributes == null)
                    {
                        productDto.NumberAttributes = new List<ProductNumberAttributeDto>();
                    }

                    //remove old attributes
                    var numberAttributesDeleted = await unitOfWork.ProductNumberAttributeRepository
                    .DeleteOldProductNumberAttributes(updatedProduct.Id, productDto.NumberAttributes.Select(x => x.AttributeId).ToList(), modDate);

                    if (numberAttributesDeleted != null && numberAttributesDeleted.Any())
                    {
                        numberAttributesDeleted.ForEach(a =>
                        {
                            unitOfWork.ProductNumberAttributeHistoryRepository.AddProductNumberAttributeHistory(a);
                        });

                        savingResult = await unitOfWork.Complete();
                        if (!savingResult) throw new Exception();
                    }

                    if (productDto.TextAttributes.Any())
                    {
                        var productTextAttributes = productDto.TextAttributes.Select(x => mapper.Map<ProductTextAttribute>(x)).ToList();
                        foreach (var productTextAttribute in productTextAttributes)
                        {
                            productTextAttribute.ProductId = updatedProduct.Id;
                            productTextAttribute.ModDate = modDate;
                            if (productTextAttribute.Id == 0)
                            {
                                unitOfWork.ProductTextAttributeRepository.AddProductTextAttribute(productTextAttribute);
                                savingResult = await unitOfWork.Complete();
                                if (!savingResult)
                                {
                                    throw new Exception();
                                }
                            }
                            else
                            {
                                unitOfWork.ProductTextAttributeRepository.UpdateProductTextAttribute(productTextAttribute);
                            }
                            unitOfWork.ProductTextAttributeHistoryRepository.AddProductTextAttributeHistory(productTextAttribute);
                            savingResult = await unitOfWork.Complete();
                            if (!savingResult) throw new Exception();
                        }
                    }
                    if (productDto.NumberAttributes.Any())
                    {
                        var productNumberAttributes = productDto.NumberAttributes.Select(x => mapper.Map<ProductNumberAttribute>(x)).ToList();
                        foreach (var productNumberAttribute in productNumberAttributes)
                        {
                            productNumberAttribute.ProductId = updatedProduct.Id;
                            productNumberAttribute.ModDate = modDate;
                            if (productNumberAttribute.Id == 0)
                            {
                                unitOfWork.ProductNumberAttributeRepository.AddProductNumberAttribute(productNumberAttribute);
                                savingResult = await unitOfWork.Complete();
                                if (!savingResult)
                                {
                                    throw new Exception();
                                }
                            }
                            else
                            {
                                unitOfWork.ProductNumberAttributeRepository.UpdateProductNumberAttribute(productNumberAttribute);
                            }
                            unitOfWork.ProductNumberAttributeHistoryRepository.AddProductNumberAttributeHistory(productNumberAttribute);
                            savingResult = await unitOfWork.Complete();
                            if (!savingResult) throw new Exception();
                        }
                    }

                    if (productDto.ProductAmounts != null && productDto.ProductAmounts.Any())
                    {
                        var productAmounts = productDto.ProductAmounts.Select(x => mapper.Map<ProductAmount>(x)).ToList();
                        foreach (var productAmount in productAmounts)
                        {
                            unitOfWork.ProductAmountRepository.UpdateProductAmount(productAmount);
                        }
                        savingResult = await unitOfWork.Complete();
                        if (!savingResult) throw new Exception();
                    }

                    if (productDto.ProductDiscounts != null && productDto.ProductDiscounts.Any())
                    {
                        var productDiscounts = productDto.ProductDiscounts.Select(x => mapper.Map<Discount>(x)).ToList();
                        foreach (var productDiscount in productDiscounts)
                        {
                            if (productDiscount.Id == 0)
                            {
                                productDiscount.ProductId = updatedProduct.Id;
                                unitOfWork.DiscountRepository.AddDiscount(productDiscount);
                            }
                            else
                            {
                                unitOfWork.DiscountRepository.UpdateDiscount(productDiscount);
                            }
                        }
                        savingResult = await unitOfWork.Complete();
                        if (!savingResult) throw new Exception();
                    }
                    transaction.Commit();
                }
                catch (Exception ex)
                {
                    transaction.Rollback();
                    return StatusCode(StatusCodes.Status500InternalServerError, "Saving data incompleted");
                }
            }
            return Ok(productDto);
        }

        [HttpGet("get-product/{id}")]
        public async Task<ActionResult<ProductDto>> GetProduct(int id)
        {
            if (id <= 0)
                return BadRequest();

            var product = await unitOfWork.ProductRepository.GetProductById(id);

            if (product == null) return NotFound();

            var productDto = mapper.Map<ProductDto>(product);
            return Ok(productDto);
        }

        [HttpGet("get-products/{category}")]
        public async Task<ActionResult<IEnumerable<ProductDto>>> GetProducts3(string category, [ModelBinder(BinderType = typeof(DynamicModelBinder))] dynamic queries)
        {
            var a = (Dictionary<string, object>)queries;
            var b = a.Select(x => x.Key).ToList();
            logger.LogError(category + " " + JsonSerializer.Serialize(a));


            DynamicControl num1 = new DynamicControl("c11", "from", null, null);
            DynamicControl num2 = new DynamicControl("c22", "to", null, null);
            FilterAttribute f1 = new FilterAttribute("lab1", "number", new List<DynamicControl>() { num1, num2 });
            DynamicControl num3 = new DynamicControl("c11a", "from", null, null);
            DynamicControl num4 = new DynamicControl("c22a", "to", null, null);
            FilterAttribute f1a = new FilterAttribute("lab1a", "number", new List<DynamicControl>() { num3, num4 });


            DynamicControl text = new DynamicControl("c222", "text", "text", null);
            FilterAttribute f2 = new FilterAttribute("text", "text", new List<DynamicControl>() { text });

            DynamicControl ch1 = new DynamicControl("ch1", "label", true, null);
            DynamicControl ch2 = new DynamicControl("ch2", "label", true, null);
            DynamicControl ch3 = new DynamicControl("ch3", "label", true, null);
            DynamicControl ch4 = new DynamicControl("ch4", "label", true, null);
            FilterAttribute f3 = new FilterAttribute("ch", "checkbox", new List<DynamicControl>() { ch1, ch2, ch3, ch4 });

            List<DynamicSelectOption> options1 = new List<DynamicSelectOption>();
            options1.Add(new DynamicSelectOption("1111", 1));
            options1.Add(new DynamicSelectOption("222222", 2));
            DynamicControl sel = new DynamicControl("sel", null, 2, options1);
            FilterAttribute f4 = new FilterAttribute("select", "select", new List<DynamicControl>() { sel });

            List<FilterAttribute> filterList = new List<FilterAttribute>();
            filterList.Add(f1);
            filterList.Add(f2);
            filterList.Add(f3);
            filterList.Add(f4);
            filterList.Add(f1a);

            ProductListData productListData = new ProductListData(filterList, new Pagination());
            // var jo=new JsonSerializerOptions{PropertyNamingPolicy=JsonNamingPolicy.CamelCase};
            // System.Console.WriteLine("aaaaa "+JsonSerializer.Serialize(productListData,jo));
            // System.Console.WriteLine("bbbbb "+JsonSerializer.Serialize(productListData.FilterList,jo));
            Response.AddHeader(productListData, "ProductListData");
            //Response.AddHeader(filterList,"Filter");
            List<ProductDto> p = new List<ProductDto>()
            {
            };

            for (int i = 0; i < 20; i++)
            {
                p.Add(new ProductDto() { Id = i });
            }

            return Ok(p);
        }

        [HttpPost("upload-images")]
        public async Task<ActionResult<IEnumerable<PhotoDto>>> UploadImages([FromForm] IEnumerable<IFormFile> files
        ,/*[FromQuery]*/int productId, bool temporary)
        {
            logger.LogError(productId.ToString());
            List<PhotoDto> addedPhotos = new List<PhotoDto>();
            var maxLp = await unitOfWork.PhotoRepository.GetMaxPhotoLp(productId);
            maxLp++;
            DateTime date = DateTime.UtcNow;
            foreach (var file in files)
            {
                try
                {
                    //logger.LogError("cccccccccccccccc11111111 "+JsonSerializer.Serialize(file));
                    var result = await photoService.AddPhotoAsync(file);
                    Photo photo = new Photo();
                    photo.ProductId = productId;
                    photo.PublicId = result.PublicId;
                    photo.Url = result.Url.AbsoluteUri;
                    photo.Lp = maxLp;
                    photo.ModDate = date;
                    unitOfWork.PhotoRepository.AddPhoto(photo);
                    var savingResult = await unitOfWork.Complete();
                    if (savingResult) maxLp++;


                    //addedPhotos.Add(new PhotoDto(){Id=i,Lp=i,Url=result.Url.AbsoluteUri});
                    addedPhotos.Add(mapper.Map<PhotoDto>(photo));
                }
                catch (Exception ex)
                {

                }


                //logger.LogError("cccccccccccccccc11111111 "+JsonSerializer.Serialize(result));

            }
            return Ok(addedPhotos);
        }

        [HttpDelete("delete-image/{id}")]
        public async Task<ActionResult> DeleteImage(int id)
        {
            if (id <= 0) return BadRequest();

            var photoToDeleted = await unitOfWork.PhotoRepository.GetPhoto(id);
            if (photoToDeleted == null) return NotFound();

            unitOfWork.PhotoRepository.DeletePhoto(id);
            var savingResult = await unitOfWork.Complete();

            if (!savingResult) return StatusCode(StatusCodes.Status500InternalServerError, "Deleting incompleted");

            var result = await photoService.DeletePhotoAsync(photoToDeleted.PublicId);
            return Ok();
        }

        [Authorize(Roles = "Admin")]
        [HttpGet("check-code-not-taken")]
        public async Task<ActionResult<bool>> CheckCodeNotTaken(string code)
        {
            if (string.IsNullOrEmpty(code)) return true;

            var product = await unitOfWork.ProductRepository.GetProductByCode(code);
            if (product != null)
            {
                return false;
            }

            return true;
        }

        [HttpGet("get-product-attributes")]
        public async Task<ActionResult<ProductAttributesWrapperDto>> GetProductAttributes(int categoryId, int productId)
        {
            if (categoryId <= 0)
                return BadRequest();

            var attributes = await unitOfWork.CategoryAttributeRepository.GetCategoryAttributes(categoryId, true);
            var parentCategoriesAttributes = await unitOfWork.CategoryAttributeRepository.GetParentCategoriesAttributes(categoryId);
            attributes.AddRange(parentCategoriesAttributes);
            attributes = attributes.OrderBy(x => x.Lp).ToList();
            var textAttributes = attributes.Where(x => x.Attribute.Type == 0).ToList();
            var numericAttributes = attributes.Where(x => x.Attribute.Type == 1).ToList();
            //get current values of attributes linked with current product
            var productTextAttributes = await unitOfWork.ProductTextAttributeRepository.GetProductTextAttributes(productId, textAttributes.Select(x => x.AttributeId).ToList());
            var productNumberAttributes = await unitOfWork.ProductNumberAttributeRepository.GetProductNumberAttributes(productId, numericAttributes.Select(x => x.AttributeId).ToList());

            var textAttributesDto = textAttributes.Select(a => mapper.Map<ProductTextAttributeDto>(a)).ToList();
            textAttributesDto.ForEach(x =>
            {
                var a = productTextAttributes.FirstOrDefault(z => z.AttributeId == x.AttributeId);
                if (a != null)
                {
                    x.Id = a.Id;
                    x.Value = a.Value;
                }
            });
            var numericAttributesDto = numericAttributes.Select(a => mapper.Map<ProductNumberAttributeDto>(a)).ToList();

            numericAttributesDto.ForEach(x =>
            {
                logger.LogError(x.AttributeId.ToString());
                var a = productNumberAttributes.FirstOrDefault(z => z.AttributeId == x.AttributeId);
                if (a != null)
                {
                    logger.LogError(x.Value.ToString());
                    x.Id = a.Id;
                    x.Value = a.Value;
                }
            });
            ProductAttributesWrapperDto productAttributesWrapperDto = new ProductAttributesWrapperDto();
            productAttributesWrapperDto.ProductTextAttributes = textAttributesDto;
            productAttributesWrapperDto.ProductNumberAttributes = numericAttributesDto;

            return Ok(productAttributesWrapperDto);
        }

        [HttpGet("get-product-amounts/{productId}")]
        public async Task<ActionResult<IEnumerable<ProductAmountDto>>> GetProductAmounts(int productId)
        {
            if (productId <= 0)
                return BadRequest();

            var warehouses = await unitOfWork.WarehouseRepository.GetWarehouses();
            var amounts = await unitOfWork.ProductAmountRepository.GetProductAmounts(productId);

            var productAmounts = amounts
            .Select(a => mapper.Map<ProductAmountDto>(a)).ToList();
            var productAmountsFromWarehouses = warehouses
            .Select(a => mapper.Map<ProductAmountDto>(a))
            .Where(x => !productAmounts.Select(z => z.WarehouseId).Contains(x.WarehouseId)).ToList();
            productAmountsFromWarehouses.ForEach(x => { x.ProductId = productId; });
            productAmounts.AddRange(productAmountsFromWarehouses);
            productAmounts = productAmounts.OrderBy(x => x.WarehouseId).ToList();

            return Ok(productAmounts);
        }

        [HttpGet("get-product-discounts/{productId}")]
        public async Task<ActionResult<IEnumerable<DiscountDto>>> GetProductDiscounts(int productId)
        {
            if (productId <= 0)
                return BadRequest();

            var discounts = await unitOfWork.DiscountRepository.GetProductDiscounts(productId);
            return Ok(discounts.Select(a => mapper.Map<DiscountDto>(a)).ToList());
        }

        [HttpGet("get-products-managment")]
        public async Task<ActionResult<IEnumerable<ProductDto>>> GetProductsManagment([FromQuery] GetProductsManagmentParamDto paramsDto)
        {
            //remove old temp products
            unitOfWork.ProductRepository.RemoveTemporaryProducts();
            var savingResult = await unitOfWork.Complete();
            //logger.LogError(aaa+" "+savingResult);
            var pagination = new Pagination();
            if (paramsDto.Page.HasValue)
            {
                pagination.Page = paramsDto.Page.Value;
            }
            if (paramsDto.ItemsPerPage.HasValue)
            {
                pagination.ItemsPerPage = paramsDto.ItemsPerPage.Value;
            }

            var productsDtos = await unitOfWork.ProductRepository.GetProductsManagment(paramsDto.Code, paramsDto.CategoryId, pagination);
            Response.AddHeader(new Pagination() { Page = productsDtos.CurrentPage, TotalPages = productsDtos.TotalPages }, "Pagination");

            return Ok(productsDtos);
        }

        [HttpDelete("delete-product/{productId:int}")]
        [Authorize]
        public async Task<ActionResult> DeleteProductId(int productId)
        {
            if (productId <= 0)
                return BadRequest();

            try
            {
                unitOfWork.ProductRepository.DeleteProduct(productId);
                bool savingResult = await unitOfWork.Complete();
                if (!savingResult) throw new Exception();
            }
            catch (Exception e)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Deleting incompleted");
            }

            return Ok();
        }
    }
}
