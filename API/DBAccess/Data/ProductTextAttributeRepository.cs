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
    public class ProductTextAttributeRepository : IProductTextAttributeRepository
    {
        private readonly DataContext context;
        private readonly IMapper mapper;

        public ProductTextAttributeRepository(DataContext context, IMapper mapper)
        {
            this.context = context;
            this.mapper = mapper;
        }

        public void AddProductTextAttribute(ProductTextAttribute productTextAttribute)
        {
            context.ProductTextAttributes.Add(productTextAttribute);
        }

        public async Task<List<ProductTextAttribute>> DeleteOldProductTextAttributes(int productId, List<int> attributesIdsToSkip, DateTime modDate)
        {
            var attributesToDelete = await context.ProductTextAttributes
            .Where(x => x.ProductId == productId && !attributesIdsToSkip.Contains(x.AttributeId))
            .ToListAsync();
            attributesToDelete.ForEach(x =>
            {
                x.Deleted = true;
                x.ModDate = modDate;
            });
            return attributesToDelete;
        }

        public async void UpdateProductTextAttribute(Entities.ProductTextAttribute productTextAttribute)
        {
            var pa = await context.ProductTextAttributes.FirstOrDefaultAsync(x => x.Id == productTextAttribute.Id);
            pa.Value = productTextAttribute.Value;
            pa.Deleted = productTextAttribute.Deleted;
            pa.ModDate = productTextAttribute.ModDate;
        }

        public async void aa()
        {
            await context.Attributes
            .Include(x => x.ProductTextAttributes)
            .Where(x => x.Type == 0)
            .ToListAsync();
        }

        public async Task<List<ProductTextAttribute>> GetProductTextAttributes(int productId, List<int> attributesIds)
        {
            return await context.ProductTextAttributes
            .Where(x => x.ProductId == productId && !x.Deleted && attributesIds.Contains(x.AttributeId))
            .ToListAsync();
        }

        public async Task<List<ProductTextAttribute>> GetProductsTextAttributeValues(int attributeId
        ,List<int> productsCategoriesIds)
        {
            return await context.ProductTextAttributes
            .Include(x=>x.Product)
            .Where(x => !x.Deleted && x.AttributeId == attributeId && !x.Product.Deleted && productsCategoriesIds.Contains(x.Product.CategoryId.Value))
            .ToListAsync();
        }

        public async Task<List<ProductTextAttribute>> GetAllProductTextAttributes(int productId)
        {
            return await context.ProductTextAttributes
            .Include(x=>x.Attribute)
            .Where(x => x.ProductId == productId && !x.Deleted)
            .ToListAsync();
        }
    }
}