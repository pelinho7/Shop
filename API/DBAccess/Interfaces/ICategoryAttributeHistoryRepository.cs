using System.Collections.Generic;
using System.Threading.Tasks;
using API.DBAccess.Data;
using API.DBAccess.Entities;
using API.DTOs;

namespace API.DBAccess.Interfaces
{
    public interface ICategoryAttributeHistoryRepository
    {
        void AddCategoryAttributeHistory(CategoryAttribute categoryAttribute);
        Task<List<CategoryAttributeHistory>> GetCategoryAttributeHistoryByIdAsync(int id);
    }
}