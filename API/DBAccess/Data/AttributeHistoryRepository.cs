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
    public class AttributeHistoryRepository : IAttributeHistoryRepository
    {
        private readonly DataContext context;
        private readonly IMapper mapper;

        public AttributeHistoryRepository(DataContext context, IMapper mapper)
        {
            this.context = context;
            this.mapper = mapper;
        }

        public void AddAttributeHistory(Entities.Attribute attribute)
        {
            context.AttributeHistories.Add(mapper.Map<Entities.Attribute,AttributeHistory>(attribute));
        }

        public async Task<List<AttributeHistory>> GetAttributeHistoryByIdAsync(int id)
        {
            return await context.AttributeHistories.Where(x=>x.AttributeId==id).ToListAsync();
        }
    }
}