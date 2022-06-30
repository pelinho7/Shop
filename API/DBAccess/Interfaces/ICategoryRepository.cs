using System.Collections.Generic;
using System.Threading.Tasks;
using API.DBAccess.Data;
using API.DBAccess.Entities;
using API.DTOs;

namespace API.DBAccess.Interfaces
{
    public interface ICategoryRepository
    {
        void AddCategory(Category category);
        Task<Category> UpdateCategory(Category category);
        Task<Category> GetCategory(int id);
        Task<List<Category>> GetCategories();
        Task<Category> GetCategoryByCode(string code);
        void DeleteCategory(int categoryId);
    }
}