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
        Task<Product> GetProductFullData(string code);
        Task<PagedList<Product>> GetProducts(Pagination pagination
        , List<int> categories
        , List<DefaultParamFilter> defaultParamFilters
        , List<TextAttributeFilter> textAttributeFilters
        , List<NumberAttributeFilter> numberAttributeFilters
        , List<CheckboxAttributeFilter> checkboxAttributeFilters);
        Task<PagedList<ProductBasicDto>> GetProductsManagment(string code, int? categoryId, Pagination pagination);
        Task<Product> UpdateProduct(Product product);
        void DeleteProduct(int productId);
        void RemoveTemporaryProducts();
    }
}