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

namespace API.Controllers
{
    public class ProductsController : BaseApiController
    {
        private readonly ILogger<ProductsController> logger;

        public ProductsController(ILogger<ProductsController> logger)
        {
            this.logger = logger;
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

        // [HttpGet("{id}")]
        // public async Task<ActionResult<AppUser>> GetUser(int id)
        // {
        //     return await _context.Users.FindAsync(id);
        // }
    }
}
