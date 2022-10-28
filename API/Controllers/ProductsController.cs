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
using API.DBAccess.Data;
using System.Globalization;

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

        [HttpGet("get-product-full-data/{code}")]
        public async Task<ActionResult<ProductFullDataDto>> GetProductFullData(string code,string location)
        {
            if (string.IsNullOrEmpty(code))
                return BadRequest();

            var product = await unitOfWork.ProductRepository.GetProductFullData(code);

            if (product == null) return NotFound();

            var productAttributesOrdered=await getProductParametersList(product.CategoryId.Value,location
                ,product.ProductTextAttributes.ToList(),product.ProductNumberAttributes.ToList());


            var productDto = mapper.Map<ProductFullDataDto>(product);
            productDto.Parameters=productAttributesOrdered.Select(x=>mapper.Map<ProductTextAttributeDto>(x)).ToList();
            logger.LogError(JsonSerializer.Serialize(productDto));
            return Ok(productDto);
        }


        [HttpGet("get-filters/{category}")]
        public async Task<ActionResult<IEnumerable<FilterAttribute>>> GetFilters(string category)
        {
            // DynamicControl num1 = new DynamicControl("c11", "from", null, null);
            // DynamicControl num2 = new DynamicControl("c22", "to", null, null);
            // FilterAttribute f1 = new FilterAttribute("lab1", "number", new List<DynamicControl>() { num1, num2 });
            // DynamicControl num3 = new DynamicControl("c11a", "from", null, null);
            // DynamicControl num4 = new DynamicControl("c22a", "to", null, null);
            // FilterAttribute f1a = new FilterAttribute("lab1a", "number", new List<DynamicControl>() { num3, num4 });


            // DynamicControl text = new DynamicControl("c222", "text", "text", null);
            // FilterAttribute f2 = new FilterAttribute("text", "text", new List<DynamicControl>() { text });

            // DynamicControl ch1 = new DynamicControl("ch1", "label", true, null);
            // DynamicControl ch2 = new DynamicControl("ch2", "label", true, null);
            // DynamicControl ch3 = new DynamicControl("ch3", "label", true, null);
            // DynamicControl ch4 = new DynamicControl("ch4", "label", true, null);
            // FilterAttribute f3 = new FilterAttribute("ch", "checkbox", new List<DynamicControl>() { ch1, ch2, ch3, ch4 });

            // List<DynamicSelectOption> options1 = new List<DynamicSelectOption>();
            // options1.Add(new DynamicSelectOption("1111", 1));
            // options1.Add(new DynamicSelectOption("222222", 2));
            // DynamicControl sel = new DynamicControl("sel", null, 2, options1);
            // FilterAttribute f4 = new FilterAttribute("select", "select", new List<DynamicControl>() { sel });

            // List<FilterAttribute> filterList = new List<FilterAttribute>();
            // filterList.Add(f1);
            // filterList.Add(f2);
            // filterList.Add(f3);
            // filterList.Add(f4);
            // filterList.Add(f1a);

            var cat = await unitOfWork.CategoryRepository.GetCategoryByCode(category);
            if (cat == null) return NotFound();
            cat = await unitOfWork.CategoryRepository.GetCategory(cat.Id);
            var parentCategoriesAttributes = await unitOfWork.CategoryAttributeRepository.GetParentCategoriesAttributes(cat.Id);
            List<CategoryAttribute> categoriesAttributes = new List<CategoryAttribute>();

            var categoriesIds = await unitOfWork.CategoryLinkRepository.GetSubCategoriesIds(cat.Id);
            categoriesIds.Add(cat.Id);

            if (parentCategoriesAttributes != null)
            {
                categoriesAttributes.AddRange(parentCategoriesAttributes.OrderBy(x => x.AttributeId).ThenBy(x => x.Lp));
            }
            if (cat.CategoryAttributes != null)
            {
                categoriesAttributes.AddRange(cat.CategoryAttributes.OrderBy(x => x.Lp));
            }

            List<FilterAttribute> filterList = new List<FilterAttribute>();
            //adding default filtering elements
            DynamicControl priceField1 = new DynamicControl($"0_{DefaultFilterParamEnum.Price.ToString().ToLower()}_from", "from", null, null);
            DynamicControl priceField2 = new DynamicControl($"0_{DefaultFilterParamEnum.Price.ToString().ToLower()}_to", "to", null, null);
            var priceFilter = new FilterAttribute("Price", "number", new List<DynamicControl>() { priceField1, priceField2 });
            filterList.Add(priceFilter);

            //categoriesAttributes=categoriesAttributes.OrderBy(x=>x.Lp).ToList();
            foreach (var attribute in categoriesAttributes)
            {
                string extendedCode = $"{attribute.AttributeId}_{attribute.Attribute.FiltrationMode}_{attribute.Code}";
                if (attribute.Attribute.FiltrationMode == (int)FiltrationModeEnum.Checkboxes)
                {
                    extendedCode = $"{attribute.AttributeId}_{attribute.Attribute.FiltrationMode}";
                }
                FilterAttribute attributeFilter = new FilterAttribute();
                if (attribute.Attribute.Type == (int)AttributeTypeEnum.Text)
                {
                    if (attribute.Attribute.FiltrationMode == (int)FiltrationModeEnum.TextField)
                    {
                        DynamicControl textField = new DynamicControl(extendedCode, attribute.Label, "", null);
                        attributeFilter = new FilterAttribute(attribute.Label, "text", new List<DynamicControl>() { textField });
                    }
                    else if (attribute.Attribute.FiltrationMode == (int)FiltrationModeEnum.Checkboxes)
                    {
                        var attributesValues = await unitOfWork.ProductTextAttributeRepository
                        .GetProductsTextAttributeValues(attribute.Attribute.Id, categoriesIds);
                        var groupedValues = attributesValues.GroupBy(x => x.Value)
                        .Select(x => new { Value = x.Key, Count = x.Count() })
                        .OrderByDescending(x => x.Count).ToList();
                        var controls = new List<DynamicControl>();
                        foreach (var value in groupedValues)
                        {
                            DynamicControl checkboxField = new DynamicControl($"{extendedCode}_{value.Value}", $"{value.Value} ({value.Count})", true, null);
                            controls.Add(checkboxField);
                        }

                        attributeFilter = new FilterAttribute(attribute.Label, "checkbox", controls);
                    }
                }
                else if (attribute.Attribute.Type == (int)AttributeTypeEnum.Number)
                {
                    DynamicControl numberField1 = new DynamicControl($"{extendedCode}_from", "from", null, null);
                    DynamicControl numberField2 = new DynamicControl($"{extendedCode}_to", "to", null, null);
                    attributeFilter = new FilterAttribute(attribute.Label, "number", new List<DynamicControl>() { numberField1, numberField2 });
                }

                if (attributeFilter != null)
                {
                    filterList.Add(attributeFilter);
                }
            }
            return Ok(filterList);
        }

        [HttpGet("get-products/{category}")]
        public async Task<ActionResult<IEnumerable<ProductListItemDto>>> GetProducts(string category, [ModelBinder(BinderType = typeof(DynamicModelBinder))] dynamic queries)
        {
            var parameters = (Dictionary<string, object>)queries;
            List<NumberAttributeFilter> numberAttributeFilters = new List<NumberAttributeFilter>();
            List<CheckboxAttributeFilter> checkboxAttributeFilters = new List<CheckboxAttributeFilter>();
            List<TextAttributeFilter> textAttributeFilters = new List<TextAttributeFilter>();
            List<DefaultParamFilter> defaultParamFilters = new List<DefaultParamFilter>();
            var cat = await unitOfWork.CategoryRepository.GetCategoryByCode(category);
            var categoriesIds = await unitOfWork.CategoryLinkRepository.GetSubCategoriesIds(cat.Id);
            categoriesIds.Add(cat.Id);
            foreach (var param in parameters)
            {
                var paramParts = param.Key.Split("_").ToList();
                if (paramParts == null || paramParts.Count() == 1)
                {
                    continue;
                }
                //0 means default filtering elements
                int atrId = int.Parse(paramParts[0]);
                if (atrId == 0)
                {
                    if (paramParts[1].ToString() == DefaultFilterParamEnum.Price.ToString().ToLower())
                    {
                        string fromTo = paramParts[paramParts.Count - 1].ToLower();
                        defaultParamFilters.Add(new DefaultParamFilter(DefaultFilterParamEnum.Price, fromTo != "to", double.Parse(param.Value.ToString())));
                    }
                }
                else
                {
                    int filtrationMode = int.Parse(paramParts[1]);
                    if (filtrationMode == (int)FiltrationModeEnum.TwoNumericFields)
                    {
                        string fromTo = paramParts[paramParts.Count - 1].ToLower();
                        numberAttributeFilters.Add(new NumberAttributeFilter(atrId, fromTo != "to", double.Parse(param.Value.ToString())));
                    }
                    else if (filtrationMode == (int)FiltrationModeEnum.Checkboxes)
                    {
                        var checkboxAtr = checkboxAttributeFilters.FirstOrDefault(x => x.AttributeId == atrId && x.Equal == bool.Parse(param.Value.ToString()));
                        if (checkboxAtr == null)
                        {
                            checkboxAtr = new CheckboxAttributeFilter(atrId, bool.Parse(param.Value.ToString()));
                            checkboxAttributeFilters.Add(checkboxAtr);
                        }
                        var atrValue = string.Join("_", paramParts.Skip(2));
                        checkboxAtr.Values.Add(atrValue);
                    }
                    else if (filtrationMode == (int)FiltrationModeEnum.TextField)
                    {
                        textAttributeFilters.Add(new TextAttributeFilter(atrId, string.Join("_", paramParts.Skip(2))));
                    }
                }
            }

            // List<DynamicSelectOption> options1 = new List<DynamicSelectOption>();
            // options1.Add(new DynamicSelectOption("1111", 1));
            // options1.Add(new DynamicSelectOption("222222", 2));
            // DynamicControl sel = new DynamicControl("sel", null, 2, options1);
            // FilterAttribute f4 = new FilterAttribute("select", "select", new List<DynamicControl>() { sel });



            var pagination = new Pagination();
            if (parameters.ContainsKey("page"))
            {
                pagination.Page = int.Parse(parameters["page"].ToString());
            }

            var products = await unitOfWork.ProductRepository.GetProducts(pagination, categoriesIds
            , defaultParamFilters, textAttributeFilters, numberAttributeFilters, checkboxAttributeFilters);
            var productsDtos = products.Select(x => mapper.Map<ProductListItemDto>(x)).ToList();

            pagination = new Pagination() { Page = products.CurrentPage, TotalPages = products.TotalPages };

            Response.AddHeader(pagination, "Pagination");

            return Ok(productsDtos);
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

            //var productAttributesWrapperDto = createProductAttributesWrapper(productTextAttributes, productNumberAttributes);

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
                    x.Id = a.Id;
                    x.Value = a.Value;
                }
            });
            ProductAttributesWrapperDto productAttributesWrapperDto = new ProductAttributesWrapperDto();
            productAttributesWrapperDto.ProductTextAttributes = textAttributesDto;
            productAttributesWrapperDto.ProductNumberAttributes = numericAttributesDto;

            return Ok(productAttributesWrapperDto);
        }

        [NonAction]
        private async Task<List<ProductTextAttribute>> getProductParametersList(int categoryId,string location
        ,List<ProductTextAttribute>productTextAttributes
        ,List<ProductNumberAttribute>productNumberAttributes)
        {
            var parentCategoriesAttributes = await unitOfWork.CategoryAttributeRepository.GetParentCategoriesAttributes(categoryId);
            var categoriesAttributes = await unitOfWork.CategoryAttributeRepository.GetCategoryAttributes(categoryId);
            parentCategoriesAttributes.AddRange(categoriesAttributes.OrderBy(x => x.Lp));

            var numberToTextAttributes = productNumberAttributes
            .Select(x => new ProductTextAttribute() { Id = x.Id, Attribute = x.Attribute, AttributeId = x.AttributeId, Value = x.Value.ToString($"N{x.Attribute.DecimalPlaces}", new CultureInfo(location)) }).ToList();
            productTextAttributes.AddRange(numberToTextAttributes);
            List<ProductTextAttribute> productAttributesOrdered = new List<ProductTextAttribute>();
            var orderDtos = parentCategoriesAttributes.Select(a => mapper.Map<ProductAttributeOrderDto>(a)).ToList();
            for (int i = 1; i <= orderDtos.Count; i++)
            {
                var attributes = productTextAttributes.Where(x => x.AttributeId == orderDtos[i - 1].AttributeId).ToList();
                if (attributes != null)
                {
                    productAttributesOrdered.AddRange(attributes);
                }
            }

            return productAttributesOrdered;
        }

        [HttpGet("get-product-all-attributes")]
        public async Task<ActionResult<IEnumerable<ProductTextAttributeDto>>> GetProductAllAttributes(
            int categoryId, int productId, string location)
        {
            if (productId <= 0)
                return BadRequest();

            if (categoryId <= 0)
                return BadRequest();

            //get current values of attributes linked with current product
            var productTextAttributes = await unitOfWork.ProductTextAttributeRepository.GetAllProductTextAttributes(productId);
            var productNumberAttributes = await unitOfWork.ProductNumberAttributeRepository.GetAllProductNumberAttributes(productId);

            // var parentCategoriesAttributes = await unitOfWork.CategoryAttributeRepository.GetParentCategoriesAttributes(categoryId);
            // var categoriesAttributes = await unitOfWork.CategoryAttributeRepository.GetCategoryAttributes(categoryId);
            // parentCategoriesAttributes.AddRange(categoriesAttributes.OrderBy(x => x.Lp));

            // var numberToTextAttributes = productNumberAttributes
            // .Select(x => new ProductTextAttribute() { Id = x.Id, Attribute = x.Attribute, AttributeId = x.AttributeId, Value = x.Value.ToString($"N{x.Attribute.DecimalPlaces}", new CultureInfo(location)) }).ToList();
            // productTextAttributes.AddRange(numberToTextAttributes);
            // List<ProductTextAttribute> productAttributesOrdered = new List<ProductTextAttribute>();
            // var orderDtos = parentCategoriesAttributes.Select(a => mapper.Map<ProductAttributeOrderDto>(a)).ToList();
            // for (int i = 1; i <= orderDtos.Count; i++)
            // {
            //     //orderDtos[i - 1].Lp = i;
            //     var attributes = productTextAttributes.Where(x => x.AttributeId == orderDtos[i - 1].AttributeId).ToList();
            //     if (attributes != null)
            //     {
            //         productAttributesOrdered.AddRange(attributes);
            //     }
            // }
            var productAttributesOrdered=await getProductParametersList(categoryId,location
                ,productTextAttributes,productNumberAttributes);
            var productAttributesDto = productAttributesOrdered.Select(a => mapper.Map<ProductTextAttributeDto>(a)).ToList();
            return Ok(productAttributesDto);
        }

        [NonAction]
        private ProductAttributesWrapperDto createProductAttributesWrapper(List<ProductTextAttribute> productTextAttributes
        , List<ProductNumberAttribute> productNumberAttributes)
        {
            var textAttributesDto = productTextAttributes.Select(a => mapper.Map<ProductTextAttributeDto>(a)).ToList();
            textAttributesDto.ForEach(x =>
            {
                var a = productTextAttributes.FirstOrDefault(z => z.AttributeId == x.AttributeId);
                if (a != null)
                {
                    x.Id = a.Id;
                    x.Value = a.Value;
                }
            });
            var numericAttributesDto = productNumberAttributes.Select(a => mapper.Map<ProductNumberAttributeDto>(a)).ToList();

            numericAttributesDto.ForEach(x =>
            {
                logger.LogError(x.AttributeId.ToString());
                var a = productNumberAttributes.FirstOrDefault(z => z.AttributeId == x.AttributeId);
                if (a != null)
                {
                    x.Id = a.Id;
                    x.Value = a.Value;
                }
            });
            ProductAttributesWrapperDto productAttributesWrapperDto = new ProductAttributesWrapperDto();
            productAttributesWrapperDto.ProductTextAttributes = textAttributesDto;
            productAttributesWrapperDto.ProductNumberAttributes = numericAttributesDto;

            return productAttributesWrapperDto;
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
