using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using API.DBAccess.Entities;
using API.DBAccess.Interfaces;
using AutoMapper;
using Microsoft.EntityFrameworkCore;

namespace API.DBAccess.Data
{
    public class CategoryHistoryRepository : ICategoryHistoryRepository
    {
        private readonly DataContext context;
        private readonly IMapper mapper;

        public CategoryHistoryRepository(DataContext context, IMapper mapper)
        {
            this.context = context;
            this.mapper = mapper;
        }

        public void AddCategoryHistory(Category category)
        {
            context.CategoryHistories.Add(mapper.Map<Category,CategoryHistory>(category));
        }

        public async Task<List<CategoryHistory>> GetCategoryHistoryByIdAsync(int id)
        {
            return await context.CategoryHistories
            .Where(x=>x.CategoryId==id).ToListAsync();
        }
    }
}