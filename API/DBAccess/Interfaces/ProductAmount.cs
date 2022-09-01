using System.Collections.Generic;
using System.Threading.Tasks;
using API.DBAccess.Data;
using API.DBAccess.Entities;
using API.DTOs;
using API.Helpers;

namespace API.DBAccess.Interfaces
{
    public interface IProductAmountRepository
    {
        void UpdateProductAmount(ProductAmount productAmount);
        Task<List<ProductAmount>> GetProductAmounts(int productId);
    }
}