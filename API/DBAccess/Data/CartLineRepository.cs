using System;
using System.Threading.Tasks;
using API.DBAccess.Entities;
using API.DBAccess.Interfaces;
using AutoMapper;
using Microsoft.EntityFrameworkCore;

namespace API.DBAccess.Data
{
    public class CartLineRepository : ICartLineRepository
    {
        private readonly DataContext context;
        private readonly IMapper mapper;
        public CartLineRepository(DataContext context, IMapper mapper)
        {
            this.context = context;
            this.mapper = mapper;
        }

        public void AddCartLine(CartLine cartLine)
        {
            cartLine.CreateDate=System.DateTime.UtcNow;
            cartLine.ModDate=cartLine.CreateDate;
            context.CartLines.Add(cartLine);        
        }

        public async void DeleteCartLine(int id)
        {
            var cartLine = await context.CartLines.FirstOrDefaultAsync(x => x.Id == id);
            context.CartLines.Remove(cartLine);
        }

        public async Task<CartLine> GetCartLine(Guid cartId, int productId)
        {
            return await context.CartLines
            .Include(x=>x.Product)
            .ThenInclude(x=>x.Photos)
            .FirstOrDefaultAsync(x=>x.CartId == cartId && x.ProductId == productId);
        }

        public async Task<CartLine> GetCartLine(int id)
        {
            return await context.CartLines
            .Include(x=>x.Product)
            .ThenInclude(x=>x.Photos)
            .FirstOrDefaultAsync(x=>x.Id == id);
        }

        public async void UpdateCartLine(CartLine cartLine)
        {
            var cl = await  context.CartLines.FirstOrDefaultAsync(x=>x.Id == cartLine.Id);
            cl.Quantity=cartLine.Quantity;
            cl.ProductId=cartLine.ProductId;
            cl.CartId=cartLine.CartId;
            cl.ModDate=System.DateTime.UtcNow;
        }

        public async void UpdateCartLineQuantity(CartLine cartLine)
        {
            var cl = await  context.CartLines.FirstOrDefaultAsync(x=>x.Id == cartLine.Id);
            cl.Quantity=cartLine.Quantity;
            cl.ModDate=System.DateTime.UtcNow;
        }
    }
}