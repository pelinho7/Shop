using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using API.DBAccess.Entities;

namespace API.DBAccess.Interfaces
{
    public interface IProductNumberAttributeRepository
    {
        void AddProductNumberAttribute(ProductNumberAttribute productNumberAttribute);
        void UpdateProductNumberAttribute(ProductNumberAttribute productNumberAttribute);
        Task<List<ProductNumberAttribute>> DeleteOldProductNumberAttributes(int productId, List<int> attributesIdsToSkip, DateTime modDate);
        Task<List<ProductNumberAttribute>> GetProductNumberAttributes(int productId, List<int> attributesIds);
    }
}