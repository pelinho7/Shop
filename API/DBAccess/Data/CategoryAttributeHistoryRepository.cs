using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using API.DBAccess.Entities;
using API.DBAccess.Interfaces;
using AutoMapper;
using Microsoft.EntityFrameworkCore;

namespace API.DBAccess.Data
{
    public class CategoryAttributeHistoryRepository:ICategoryAttributeHistoryRepository
    {
        private readonly DataContext context;
        private readonly IMapper mapper;

        public CategoryAttributeHistoryRepository(DataContext context, IMapper mapper)
        {
            this.context = context;
            this.mapper = mapper;
        }

        public void AddCategoryAttributeHistory(CategoryAttribute categoryAttribute)
        {
            context.CategoryAttributeHistories.Add(mapper.Map<CategoryAttribute,CategoryAttributeHistory>(categoryAttribute));
        }

        public async Task<List<CategoryAttributeHistory>> GetCategoryAttributeHistoryByIdAsync(int id)
        {
            return await context.CategoryAttributeHistories
            .Include(x=>x.Attribute)
            .Where(x=>x.CategoryId==id).ToListAsync();
        }
    }
}