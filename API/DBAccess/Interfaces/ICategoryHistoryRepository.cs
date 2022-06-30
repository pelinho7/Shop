using System.Collections.Generic;
using System.Threading.Tasks;
using API.DBAccess.Data;
using API.DBAccess.Entities;
using API.DTOs;

namespace API.DBAccess.Interfaces
{
    public interface ICategoryHistoryRepository
    {
        void AddCategoryHistory(Category category);
        Task<List<CategoryHistory>> GetCategoryHistoryByIdAsync(int id);
    }
}