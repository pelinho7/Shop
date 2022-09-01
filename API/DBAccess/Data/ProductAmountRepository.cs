using System.Threading.Tasks;
using API.DBAccess.Entities;
using API.DBAccess.Interfaces;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Collections.Generic;
using API.Helpers;
using API.DTOs;
using AutoMapper.QueryableExtensions;

namespace API.DBAccess.Data
{
    public class ProductAmountRepository : IProductAmountRepository
    {
        private readonly DataContext context;
        private readonly IMapper mapper;
        public ProductAmountRepository(DataContext context, IMapper mapper)
        {
            this.context = context;
            this.mapper = mapper;
        }

        public async Task<List<ProductAmount>> GetProductAmounts(int productId)
        {
            return await context.ProductAmounts
            .Include(x=>x.Warehouse)
            .Where(x=>x.ProductId == productId)
            .ToListAsync();
        }

        public async void UpdateProductAmount(ProductAmount productAmount)
        {
            var pa = await  context.ProductAmounts.FirstOrDefaultAsync(x=>x.WarehouseId == productAmount.WarehouseId && x.ProductId == productAmount.ProductId);
            if(pa==null){
               context.ProductAmounts.Add(productAmount);      
            }
            else{
                pa.Amount=productAmount.Amount;
                pa.ModDate=System.DateTime.UtcNow;
            }
        }
    }
}