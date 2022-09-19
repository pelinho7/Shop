using System.Collections.Generic;
using System.Threading.Tasks;
using API.DBAccess.Entities;

namespace API.DBAccess.Interfaces
{
    public interface IDiscountRepository
    {
        void AddDiscount(Discount discount);
        void UpdateDiscount(Discount discount);
        Task<List<Discount>> GetProductDiscounts(int productId);
    }
}