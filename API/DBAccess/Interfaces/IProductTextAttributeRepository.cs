using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using API.DBAccess.Entities;
using API.DTOs;
using API.Helpers;

namespace API.DBAccess.Interfaces
{
    public interface IProductTextAttributeRepository
    {
        void AddProductTextAttribute(ProductTextAttribute productTextAttribute);
        void UpdateProductTextAttribute(ProductTextAttribute productTextAttribute);
        Task<List<ProductTextAttribute>> DeleteOldProductTextAttributes(int productId, List<int> attributesIdsToSkip, DateTime modDate);
        Task<List<ProductTextAttribute>> GetProductTextAttributes(int productId, List<int> attributesIds);
        Task<List<ProductTextAttribute>> GetAllProductTextAttributes(int productId);
        Task<List<ProductTextAttribute>> GetProductsTextAttributeValues(int attributeId, List<int> productsCategoriesIds);
    }
}