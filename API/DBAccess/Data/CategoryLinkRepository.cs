using API.DBAccess.Entities;
using API.DBAccess.Interfaces;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.DBAccess.Data
{
    public class CategoryLinkRepository:ICategoryLinkRepository
    {
        private readonly DataContext context;
        private readonly IMapper mapper;

        public CategoryLinkRepository(DataContext context, IMapper mapper)
        {
            this.context = context;
            this.mapper = mapper;
        }

        public async void UpsertCategoryLinks(Category category)
        {
            var linksToDelete = await context.CategoryLinks.Where(x=>x.CategoryId == category.Id).ToListAsync();
            context.RemoveRange(linksToDelete);
            var parentLinks = await context.CategoryLinks.Where(x=>x.CategoryId == category.ParentCategoryId.Value).ToListAsync();
            var linksToAdd = parentLinks.Select(x=>new CategoryLink(){CategoryId=category.Id,ParentCategoryId=x.ParentCategoryId}).ToList();
            linksToAdd.Add(new CategoryLink(){CategoryId=category.Id,ParentCategoryId=category.ParentCategoryId.Value});
            await context.AddRangeAsync(linksToAdd);
        }

        public async Task<List<int>> GetSubCategoriesIds(int parentCategoryId)
        {
            return await context.CategoryLinks
            .Where(x=>x.ParentCategoryId==parentCategoryId)
            .Select(x=>x.CategoryId)
            .Distinct()
            .ToListAsync();
        }
    }
}