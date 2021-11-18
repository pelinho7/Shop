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

            List<DynamicControl> controlList=new List<DynamicControl>();
            DynamicControl d1=new DynamicControl("c1","number",5,null);
            controlList.Add(d1);
            Response.AddHeader(controlList,"Filter");
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
