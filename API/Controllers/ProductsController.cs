using API.Data;
using API.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;

namespace API.Controllers
{
    public class ProductsController : BaseApiController
    {
        public ProductsController()
        {

        }

        [HttpGet]
        public /*async Task<ActionResult>*/ActionResult GetProducts([ModelBinder(BinderType = typeof(DynamicModelBinder))]dynamic queries)
        {
            //var a=((List<KeyValuePair<string, object>>)queries);
            var a=(Dictionary<string, object>)queries;
            var b=a.Select(x=>x.Key).ToList();

            var options=new JsonSerializerOptions{PropertyNamingPolicy=JsonNamingPolicy.CamelCase};
            var json=JsonSerializer.Serialize(queries,options);
            return Ok(json);
        }

        // [HttpGet("{id}")]
        // public async Task<ActionResult<AppUser>> GetUser(int id)
        // {
        //     return await _context.Users.FindAsync(id);
        // }
    }
}
