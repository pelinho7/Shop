using System.Collections.Generic;
using System.Threading.Tasks;
using API.DBAccess.Entities;
using API.DTOs;
using API.Helpers;

namespace API.DBAccess.Interfaces
{
    public interface IAttributeRepository
    {
        void AddAttribute(Attribute attribute);
        void UpdateAttribute(Attribute attribute);
        void DeleteAttribute(int attributeId);
        Task<Attribute> GetAttributeByCode(string code);
        Task<Attribute> GetAttributeById(int id);
        Task<PagedList<AttributeDto>> GetAttributes(string code,int? type,Pagination pagination=null);
    }
}