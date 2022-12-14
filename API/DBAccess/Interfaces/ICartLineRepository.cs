using System;
using System.Threading.Tasks;
using API.DBAccess.Entities;

namespace API.DBAccess.Interfaces
{
    public interface ICartLineRepository
    {
        void AddCartLine(CartLine cartLine);
        void UpdateCartLine(CartLine cartLine);
        Task<CartLine> GetCartLine(Guid cartId, int productId);
        Task<CartLine> GetCartLine(int id);
        void DeleteCartLine(int id);
        void UpdateCartLineQuantity(CartLine cartLine);
    }
}