using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using API.DTOs;
using Microsoft.EntityFrameworkCore;
using AutoMapper.QueryableExtensions;
using AutoMapper;
using API.Helpers;
using System;
using API.DBAccess.Interfaces;
using API.DBAccess.Entities;
using API.DBAccess.Data;

namespace API.DBAccess.Data
{
    public class AttributeRepository : IAttributeRepository
    {
        private readonly DataContext context;
        private readonly IMapper mapper;
        private readonly IAttributeHistoryRepository attributeHistoryRepository;

        public AttributeRepository(DataContext context, IMapper mapper,IAttributeHistoryRepository attributeHistoryRepository)
        {
            this.context = context;
            this.mapper = mapper;
            this.attributeHistoryRepository = attributeHistoryRepository;
        }

        public void AddAttribute(Entities.Attribute attribute)
        {
            context.Attributes.Add(attribute);
        }

        public async void DeleteAttribute(int attributeId)
        {
            var attribute = await context.Attributes.FirstOrDefaultAsync(x=>x.Id == attributeId);
            attribute.Deleted=true;
            attribute.ModDate=System.DateTime.UtcNow;
            attributeHistoryRepository.AddAttributeHistory(attribute);
        }

        public async Task<Entities.Attribute> GetAttributeByCode(string code)
        {
            return await context.Attributes.FirstOrDefaultAsync(x=>x.Code.ToUpper() == code.ToUpper() && !x.Deleted);
        }

        public async Task<Entities.Attribute> GetAttributeById(int id)
        {
            return await context.Attributes.FirstOrDefaultAsync(x=>x.Id == id && !x.Deleted);
        }

        public async Task<PagedList<AttributeDto>> GetAttributes(string code, int? type, Pagination pagination = null)
        {
            var query=context.Attributes.AsQueryable();
            query=query.Where(x=>!x.Deleted);
            if(!string.IsNullOrEmpty(code)) query=query.Where(x=>x.Code.ToUpper().Contains(code.ToUpper()));
            if(type.HasValue) query=query.Where(x=>x.Type == type.Value);
            query = query.OrderBy(x=>x.Id);
            return await PagedList<AttributeDto>.CreateAsync(
                query.ProjectTo<AttributeDto>(mapper.ConfigurationProvider).AsNoTracking()
                ,pagination.Page,pagination.ItemsPerPage);
        }

        public async void UpdateAttribute(Entities.Attribute attribute)
        {
            var att = await  context.Attributes.FirstOrDefaultAsync(x=>x.Id == attribute.Id);
            att.Label=attribute.Label;
            att.FiltrationMode=attribute.FiltrationMode;
            att.DecimalPlaces=attribute.DecimalPlaces;
            att.Deleted=attribute.Deleted;
            att.ModDate=System.DateTime.UtcNow;

            attributeHistoryRepository.AddAttributeHistory(att);
        }
    }
}