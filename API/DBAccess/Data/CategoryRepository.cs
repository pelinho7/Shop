using System.Threading.Tasks;
using API.DBAccess.Entities;
using API.DBAccess.Interfaces;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Collections.Generic;

namespace API.DBAccess.Data
{
    public class CategoryRepository : ICategoryRepository
    {
        private readonly DataContext context;
        private readonly IMapper mapper;
        private readonly ICategoryHistoryRepository categoryHistoryRepository;
        public CategoryRepository(DataContext context, IMapper mapper,ICategoryHistoryRepository categoryHistoryRepository)
        {
            this.context = context;
            this.mapper = mapper;
            this.categoryHistoryRepository = categoryHistoryRepository;
        }

        public void AddCategory(Category category)
        {
            context.Categories.Add(category);        
        }

        public async void DeleteCategory(int categoryId)
        {
            var category = await context.Categories.FirstOrDefaultAsync(x=>x.Id == categoryId);
            category.Deleted=true;
            category.ModDate=System.DateTime.UtcNow;
            categoryHistoryRepository.AddCategoryHistory(category);
        }

        public async Task<List<Category>> GetCategories()
        {
            return await context.Categories.ToListAsync();
        }

        public async Task<Category> GetCategory(int id)
        {
            return await context.Categories
            .Include(x=>x.CategoryAttributes.Where(z=>!z.Deleted && !z.Attribute.Deleted)).ThenInclude(x=>x.Attribute)
            .FirstOrDefaultAsync(x=>x.Id == id);
        }

        public async Task<Category> GetCategoryByCode(string code)
        {
            return await context.Categories.FirstOrDefaultAsync(x=>x.Code.ToUpper() == code.ToUpper() && !x.Deleted);
        }



        public async Task<Category> UpdateCategory(Category category)
        {
            var cat = await  context.Categories.FirstOrDefaultAsync(x=>x.Id == category.Id);
            cat.Label=category.Label;
            cat.Deleted=category.Deleted;
            cat.ModDate=System.DateTime.UtcNow;
            return cat;
        }
    }
}