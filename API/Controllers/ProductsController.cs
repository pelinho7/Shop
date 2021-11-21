using API.Data;
using API.DTOs;
using API.Entities;
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
        public ProductsController()
        {

        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<ProductDto>>> GetProducts([ModelBinder(BinderType = typeof(DynamicModelBinder))]dynamic queries)
        {
            //var a=((List<KeyValuePair<string, object>>)queries);
            var a=(Dictionary<string, object>)queries;
            var b=a.Select(x=>x.Key).ToList();

            var options=new JsonSerializerOptions{PropertyNamingPolicy=JsonNamingPolicy.CamelCase};
            var json=JsonSerializer.Serialize(queries,options);

            DynamicControl num1=new DynamicControl("c11","from",null,null);
            DynamicControl num2=new DynamicControl("c22","to",null,null);
            FilterAttribute f1=new FilterAttribute("lab1","number",new List<DynamicControl>(){num1,num2});

            List<FilterAttribute> filterList=new List<FilterAttribute>();
            filterList.Add(f1);

            // List<DynamicControl> controlList=new List<DynamicControl>();
            // List<DynamicSelectOption> options1=new List<DynamicSelectOption>();
            // options1.Add(new DynamicSelectOption("1111",1));
            // options1.Add(new DynamicSelectOption("222222",2));
            // DynamicControl d1=new DynamicControl("c1","number","from",null,null);
            // DynamicControl d2=new DynamicControl("c2","text","dsada",null,null);
            // DynamicControl d3=new DynamicControl("c1","checkbox","label",true,null);
            // DynamicControl d4=new DynamicControl("c1","select",null,2,options1);
            // controlList.Add(d1);
            // controlList.Add(d2);
            // controlList.Add(d3);
            // controlList.Add(d4);
            Response.AddHeader(filterList,"Filter");
            List<ProductDto> p=new List<ProductDto>(){
                new ProductDto(){Id=1},
                new ProductDto(){Id=2},
            };

            return Ok(p);
        }

        // [HttpGet("{id}")]
        // public async Task<ActionResult<AppUser>> GetUser(int id)
        // {
        //     return await _context.Users.FindAsync(id);
        // }
    }
}
