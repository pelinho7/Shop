using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using API.DBAccess.Entities;

namespace API.DBAccess.Interfaces
{
    public interface ICartRepository
    {
        void AddCart(Cart cart);
        void UpdateCart(Cart cart);
        Task<Cart> GetCart(Guid id);
        Task<List<CartLine>> GetCartPrices(Guid id);
    }
}