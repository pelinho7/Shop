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
    public class ProductNumberAttributeRepository : IProductNumberAttributeRepository
    {
        private readonly DataContext context;
        private readonly IMapper mapper;

        public ProductNumberAttributeRepository(DataContext context, IMapper mapper)
        {
            this.context = context;
            this.mapper = mapper;
        }

        public void AddProductNumberAttribute(ProductNumberAttribute productNumberAttribute)
        {
            context.ProductNumberAttributes.Add(productNumberAttribute);
        }

        public async Task<List<ProductNumberAttribute>> DeleteOldProductNumberAttributes(int productId, List<int> attributesIdsToSkip, DateTime modDate)
        {
            var attributesToDelete = await context.ProductNumberAttributes
            .Where(x=>x.ProductId==productId && !attributesIdsToSkip.Contains(x.AttributeId))
            .ToListAsync();
            attributesToDelete.ForEach(x=>{
                x.Deleted=true;
                x.ModDate=modDate;
                });
            return attributesToDelete;        
        }

        public async Task<List<ProductNumberAttribute>> GetProductNumberAttributes(int productId, List<int> attributesIds)
        {
            return await context.ProductNumberAttributes
            .Where(x=>x.ProductId==productId && !x.Deleted && attributesIds.Contains(x.AttributeId))
            .ToListAsync();        }

        public async void UpdateProductNumberAttribute(ProductNumberAttribute productNumberAttribute)
        {
            var pa = await context.ProductNumberAttributes.FirstOrDefaultAsync(x=>x.Id == productNumberAttribute.Id);
            pa.Value=productNumberAttribute.Value;
            pa.Deleted=productNumberAttribute.Deleted;
            pa.ModDate=productNumberAttribute.ModDate;  
        }
    }
}