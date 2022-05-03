using System.Collections.Generic;
using System.Threading.Tasks;
using API.DBAccess.Entities;
using API.DTOs;
using API.Helpers;

namespace API.DBAccess.Interfaces
{
    public interface IAttributeHistoryRepository
    {
        void AddAttributeHistory(Attribute attribute);
        Task<List<AttributeHistory>> GetAttributeHistoryByIdAsync(int id);
    }
}