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
    public class DiscountRepository : IDiscountRepository
    {
        private readonly DataContext context;
        private readonly IMapper mapper;
        public DiscountRepository(DataContext context, IMapper mapper)
        {
            this.context = context;
            this.mapper = mapper;
        }

        public void AddDiscount(Discount discount)
        {
            discount.StartDate=new System.DateTime(discount.StartDate.Year,discount.StartDate.Month,discount.StartDate.Day,0,0,0);
            discount.EndDate=(new System.DateTime(discount.EndDate.Year,discount.EndDate.Month,discount.EndDate.Day)).AddDays(1).AddMilliseconds(-1);
            context.Discounts.Add(discount);
        }

        public async Task<List<Discount>> GetProductDiscounts(int productId)
        {
            return await context.Discounts
            .Where(x=>!x.Deleted && x.ProductId==productId)
            .ToListAsync();
        }

        public async void UpdateDiscount(Discount discount)
        {
            var d = await context.Discounts.FirstOrDefaultAsync(x=>x.Id == discount.Id);
            d.Type=discount.Type;
            d.Value=discount.Value;
            d.ProductId=discount.ProductId;
            d.Deleted=discount.Deleted;
            d.StartDate=new System.DateTime(d.StartDate.Year,d.StartDate.Month,d.StartDate.Day,0,0,0);
            d.EndDate=(new System.DateTime(d.EndDate.Year,d.EndDate.Month,d.EndDate.Day)).AddDays(1).AddMilliseconds(-1);
            d.ModDate=System.DateTime.UtcNow;
        }
    }
}