using System.Collections.Generic;
using System.Threading.Tasks;
using API.DBAccess.Entities;
using API.DTOs;
using API.Helpers;

namespace API.DBAccess.Interfaces
{
    public interface IProductRepository
    {
        void AddProduct(Product product);
        Task<Product> GetProductById(int id);
        Task<Product> GetProductByCode(string code);

    }
}