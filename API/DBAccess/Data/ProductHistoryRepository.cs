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
    public class ProductHistoryRepository : IProductHistoryRepository
    {
        private readonly DataContext context;
        private readonly IMapper mapper;

        public ProductHistoryRepository(DataContext context, IMapper mapper)
        {
            this.context = context;
            this.mapper = mapper;
        }
    }
}