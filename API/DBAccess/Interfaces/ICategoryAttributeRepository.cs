using System.Collections.Generic;
using System.Threading.Tasks;
using API.DBAccess.Data;
using API.DBAccess.Entities;
using API.DTOs;

namespace API.DBAccess.Interfaces
{
    public interface ICategoryAttributeRepository
    {
        void AddCategoryAttribute(CategoryAttribute categoryAttribute);
        void UpdateCategoryAttribute(CategoryAttribute categoryAttribute);
        Task<List<CategoryAttribute>> GetCategoryAttributes(int categoryId);
        Task<List<CategoryAttribute>> GetParentCategoriesAttributes(int categoryId);
    }
}