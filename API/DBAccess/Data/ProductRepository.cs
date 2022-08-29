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
    public class ProductRepository : IProductRepository
    {
        private readonly DataContext context;
        private readonly IMapper mapper;

        public ProductRepository(DataContext context, IMapper mapper)
        {
            this.context = context;
            this.mapper = mapper;
        }

        public void AddProduct(Product product)
        {
            context.Products.Add(product);     
        }

        public async Task<Product> GetProductByCode(string code)
        {
            return await context.Products
            .Where(x=>x.Code==code)
            .FirstOrDefaultAsync();
        }

        public async Task<Product> GetProductById(int id)
        {
            return await context.Products.Include(x=>x.Photos.Where(z=>!z.Deleted))
            .Where(x=>x.Id==id)
            .FirstOrDefaultAsync();
        }
    }
}