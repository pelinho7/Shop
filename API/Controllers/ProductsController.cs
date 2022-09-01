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
            ,ILogger<ProductsController> logger,IPhotoService photoService)
        {
            this.unitOfWork = unitOfWork;
            this.mapper = mapper;
            this.logger = logger;
            this.photoService = photoService;
        }

        [HttpPost("create-product")]
        public async Task<ActionResult<ProductDto>> CreateProduct(){
            Product newProduct=new Product(){Temporary=true,CreateDate=DateTime.UtcNow,ModDate=DateTime.UtcNow};
            unitOfWork.ProductRepository.AddProduct(newProduct);
            var savingResult = await unitOfWork.Complete();

            if (!savingResult) return StatusCode(StatusCodes.Status500InternalServerError, "Saving data incompleted");

            var productDto=mapper.Map<ProductDto>(newProduct);
            return Ok(productDto);
        }

        [HttpGet("get-product/{id}")]
        public async Task<ActionResult<ProductDto>> CreateProduct(int id){
            if(id<=0)
                return BadRequest();

            var product = await unitOfWork.ProductRepository.GetProductById(id);

            if (product==null) return NotFound();

            var productDto=mapper.Map<ProductDto>(product);
            return Ok(productDto);
        }

        [HttpGet("get-products/{category}")]
        public async Task<ActionResult<IEnumerable<ProductDto>>> GetProducts3(string category,[ModelBinder(BinderType = typeof(DynamicModelBinder))]dynamic queries)
        {
            var a=(Dictionary<string, object>)queries;
            var b=a.Select(x=>x.Key).ToList();
            logger.LogError(category+" "+JsonSerializer.Serialize(a));


            DynamicControl num1=new DynamicControl("c11","from",null,null);
            DynamicControl num2=new DynamicControl("c22","to",null,null);
            FilterAttribute f1=new FilterAttribute("lab1","number",new List<DynamicControl>(){num1,num2});
            DynamicControl num3=new DynamicControl("c11a","from",null,null);
            DynamicControl num4=new DynamicControl("c22a","to",null,null);
            FilterAttribute f1a=new FilterAttribute("lab1a","number",new List<DynamicControl>(){num3,num4});


            DynamicControl text=new DynamicControl("c222","text","text",null);
            FilterAttribute f2=new FilterAttribute("text","text",new List<DynamicControl>(){text});

            DynamicControl ch1=new DynamicControl("ch1","label",true,null);
            DynamicControl ch2=new DynamicControl("ch2","label",true,null);
            DynamicControl ch3=new DynamicControl("ch3","label",true,null);
            DynamicControl ch4=new DynamicControl("ch4","label",true,null);
            FilterAttribute f3=new FilterAttribute("ch","checkbox",new List<DynamicControl>(){ch1,ch2,ch3,ch4});

            List<DynamicSelectOption> options1=new List<DynamicSelectOption>();
            options1.Add(new DynamicSelectOption("1111",1));
            options1.Add(new DynamicSelectOption("222222",2));
            DynamicControl sel=new DynamicControl("sel",null,2,options1);
            FilterAttribute f4=new FilterAttribute("select","select",new List<DynamicControl>(){sel});

            List<FilterAttribute> filterList=new List<FilterAttribute>();
            filterList.Add(f1);
            filterList.Add(f2);
            filterList.Add(f3);
            filterList.Add(f4);
            filterList.Add(f1a);

            ProductListData productListData=new ProductListData(filterList,new Pagination());
            // var jo=new JsonSerializerOptions{PropertyNamingPolicy=JsonNamingPolicy.CamelCase};
            // System.Console.WriteLine("aaaaa "+JsonSerializer.Serialize(productListData,jo));
            // System.Console.WriteLine("bbbbb "+JsonSerializer.Serialize(productListData.FilterList,jo));
            Response.AddHeader(productListData,"ProductListData");
            //Response.AddHeader(filterList,"Filter");
            List<ProductDto> p=new List<ProductDto>(){
            };

            for(int i=0;i<20;i++){
                p.Add(new ProductDto(){Id=i});
            }

            return Ok(p);
        }

        [HttpPost("upload-images")]
        public async Task<ActionResult<IEnumerable<PhotoDto>>> UploadImages([FromForm]IEnumerable<IFormFile> files
        ,/*[FromQuery]*/int productId,bool temporary)
        {
            logger.LogError(productId.ToString());
            List<PhotoDto> addedPhotos=new List<PhotoDto>();
            var maxLp = await unitOfWork.PhotoRepository.GetMaxPhotoLp(productId);
            maxLp++;
            DateTime date=DateTime.UtcNow;
            foreach(var file in files){
                try{
                    //logger.LogError("cccccccccccccccc11111111 "+JsonSerializer.Serialize(file));
                    var result = await photoService.AddPhotoAsync(file);
                    Photo photo=new Photo();
                    photo.ProductId=productId;
                    photo.PublicId=result.PublicId;
                    photo.Url=result.Url.AbsoluteUri;
                    photo.Lp=maxLp;
                    photo.ModDate=date;
                    unitOfWork.PhotoRepository.AddPhoto(photo);
                    var savingResult = await unitOfWork.Complete();
                    if (savingResult) maxLp++;


    //addedPhotos.Add(new PhotoDto(){Id=i,Lp=i,Url=result.Url.AbsoluteUri});
                    addedPhotos.Add(mapper.Map<PhotoDto>(photo));
                }
                catch(Exception ex){

                }


            //logger.LogError("cccccccccccccccc11111111 "+JsonSerializer.Serialize(result));

            }
            return Ok(addedPhotos);
        }

        [HttpDelete("delete-image/{id}")]
        public async Task<ActionResult> DeleteImage(int id)
        {
            if(id<=0) return BadRequest();
            
            var photoToDeleted = await unitOfWork.PhotoRepository.GetPhoto(id);
            if(photoToDeleted == null) return NotFound();

            unitOfWork.PhotoRepository.DeletePhoto(id);
            var savingResult = await unitOfWork.Complete();

            if(!savingResult) return StatusCode(StatusCodes.Status500InternalServerError, "Deleting incompleted");

            var result = await photoService.DeletePhotoAsync(photoToDeleted.PublicId);
            return Ok();
        }

        [Authorize(Roles ="Admin")]
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

        [HttpGet("get-product-attributes/{categoryId}")]
        public async Task<ActionResult<ProductAttributesWrapperDto>> GetProductAttributes(int categoryId){
            if(categoryId<=0)
                return BadRequest();

            var attributes = await unitOfWork.CategoryAttributeRepository.GetCategoryAttributes(categoryId,true);
            var parentCategoriesAttributes = await unitOfWork.CategoryAttributeRepository.GetParentCategoriesAttributes(categoryId);
            attributes.AddRange(parentCategoriesAttributes);
            attributes=attributes.OrderBy(x=>x.Lp).ToList();
            var textAttributes= attributes.Where(x=>x.Attribute.Type == 0).ToList();
            var numericAttributes= attributes.Where(x=>x.Attribute.Type == 1).ToList();

            var textAttributesDto = textAttributes.Select(a=>mapper.Map<ProductTextAttributeDto>(a)).ToList();
            var numericAttributesDto = numericAttributes.Select(a=>mapper.Map<ProductNumberAttributeDto>(a)).ToList();
            ProductAttributesWrapperDto productAttributesWrapperDto=new ProductAttributesWrapperDto();
            productAttributesWrapperDto.ProductTextAttributes=textAttributesDto;
            productAttributesWrapperDto.ProductNumberAttributes=numericAttributesDto;

            return Ok(productAttributesWrapperDto);
        }

        [HttpGet("get-product-amounts/{productId}")]
        public async Task<ActionResult<IEnumerable<ProductAmountDto>>> GetProductAmounts(int productId){
            if(productId<=0)
                return BadRequest();

            var warehouses=await unitOfWork.WarehouseRepository.GetWarehouses();
            var amounts = await unitOfWork.ProductAmountRepository.GetProductAmounts(productId);

            var productAmounts = amounts
            .Select(a=>mapper.Map<ProductAmountDto>(a)).ToList();
            var productAmountsFromWarehouses = warehouses
            .Select(a=>mapper.Map<ProductAmountDto>(a))
            .Where(x=>!productAmounts.Select(z=>z.WarehouseId).Contains(x.WarehouseId)).ToList();
            productAmountsFromWarehouses.ForEach(x=>{x.ProductId=productId;});
            productAmounts.AddRange(productAmountsFromWarehouses);
            productAmounts = productAmounts.OrderBy(x=>x.WarehouseId).ToList();
            // var parentCategoriesAttributes = await unitOfWork.CategoryAttributeRepository.GetParentCategoriesAttributes(categoryId);
            // attributes.AddRange(parentCategoriesAttributes);
            // attributes=attributes.OrderBy(x=>x.Lp).ToList();
            // var textAttributes= attributes.Where(x=>x.Attribute.Type == 0).ToList();
            // var numericAttributes= attributes.Where(x=>x.Attribute.Type == 1).ToList();

            // var textAttributesDto = textAttributes.Select(a=>mapper.Map<ProductTextAttributeDto>(a)).ToList();
            // var numericAttributesDto = numericAttributes.Select(a=>mapper.Map<ProductNumberAttributeDto>(a)).ToList();
            // ProductAttributesWrapperDto productAttributesWrapperDto=new ProductAttributesWrapperDto();
            // productAttributesWrapperDto.ProductTextAttributes=textAttributesDto;
            // productAttributesWrapperDto.ProductNumberAttributes=numericAttributesDto;

            return Ok(productAmounts);
        }
    }
}
