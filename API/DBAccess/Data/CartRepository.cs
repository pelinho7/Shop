using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using API.DBAccess.Entities;
using API.DBAccess.Interfaces;
using AutoMapper;
using Microsoft.EntityFrameworkCore;

namespace API.DBAccess.Data
{
    public class CartRepository : ICartRepository
    {
        private readonly DataContext context;
        private readonly IMapper mapper;
        public CartRepository(DataContext context, IMapper mapper)
        {
            this.context = context;
            this.mapper = mapper;
        }

        public void AddCart(Cart cart)
        {
            cart.CreateDate=System.DateTime.UtcNow;
            cart.ModDate=cart.CreateDate;
            context.Carts.Add(cart);        
        }

        public async Task<Cart> GetCart(Guid id)
        {
            return await context.Carts
            .Include(x=>x.CartLines)  
            .ThenInclude(x=>x.Product)
            .ThenInclude(x=>x.Photos)
            .Where(x=>x.ModDate.AddDays(1)>=DateTime.UtcNow)
            .FirstOrDefaultAsync(x=>x.Id==id);
        }

        public async void UpdateCart(Cart cart)
        {
            var ca = await  context.Carts.FirstOrDefaultAsync(x=>x.Id == cart.Id);
            ca.ModDate=System.DateTime.UtcNow;
        }

        public async Task<List<CartLine>> GetCartPrices(Guid id)
        {
            return await context.CartLines
            .Include(x=>x.Product)
            .ThenInclude(x=>x.Discounts.Where(x=>!x.Deleted && x.StartDate<=DateTime.UtcNow && x.EndDate>=DateTime.UtcNow))
            .Where(x=>x.CartId==id)
            .ToListAsync();
        }
    }
}