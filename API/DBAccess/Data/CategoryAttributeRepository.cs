using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using API.DBAccess.Entities;
using API.DBAccess.Interfaces;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using Microsoft.EntityFrameworkCore;

namespace API.DBAccess.Data
{
    public class CategoryAttributeRepository:ICategoryAttributeRepository
    {
        private readonly DataContext context;
        private readonly IMapper mapper;
        private readonly ICategoryAttributeHistoryRepository categoryAttributeHistoryRepository;
        public CategoryAttributeRepository(DataContext context, IMapper mapper,ICategoryAttributeHistoryRepository categoryAttributeHistoryRepository)
        {
            this.context = context;
            this.mapper = mapper;
            this.categoryAttributeHistoryRepository = categoryAttributeHistoryRepository;
        }

        public void AddCategoryAttribute(CategoryAttribute categoryAttribute)
        {
            context.CategoryAttributes.Add(categoryAttribute);        
        }

        public async void UpdateCategoryAttribute(CategoryAttribute categoryAttribute)
        {
            var ca = await  context.CategoryAttributes.FirstOrDefaultAsync(x=>x.Id == categoryAttribute.Id);
            ca.AttributeId=categoryAttribute.AttributeId;
            ca.Lp=categoryAttribute.Lp;
            ca.Deleted=categoryAttribute.Deleted;
            ca.ModDate=categoryAttribute.ModDate;
        }

        public async Task<List<CategoryAttribute>> GetCategoryAttributes(int categoryId)
        {
            return await context.CategoryAttributes.Where(x=>!x.Deleted && x.CategoryId==categoryId).ToListAsync();
        }

        public async Task<List<CategoryAttribute>> GetParentCategoriesAttributes(int categoryId)
        {
            return await context.CategoryLinks
            .Include(x=>x.ParentCategory).ThenInclude(x=>x.CategoryAttributes.Where(z=>!z.Deleted)).ThenInclude(x=>x.Attribute)
            .Where(x=>x.CategoryId == categoryId)
            .Select(x=>x.ParentCategory)
            .SelectMany(x=>x.CategoryAttributes)
            .Where(x=>!x.Deleted)
            .ToListAsync();
        }
    }
}