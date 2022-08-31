using System.Threading.Tasks;
using API.DBAccess.Entities;
using API.DBAccess.Interfaces;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Collections.Generic;
using API.Helpers;
using API.DTOs;
using AutoMapper.QueryableExtensions;

namespace API.DBAccess.Data
{
    public class WarehouseRepository : IWarehouseRepository
    {
        private readonly DataContext context;
        private readonly IMapper mapper;
        public WarehouseRepository(DataContext context, IMapper mapper)
        {
            this.context = context;
            this.mapper = mapper;
        }

        public void AddWarehouse(Warehouse warehouse)
        {
            context.Warehouses.Add(warehouse);        
        }

        public async void DeleteWarehouse(int warehouseId)
        {
            var warehouse = await context.Warehouses.FirstOrDefaultAsync(x=>x.Id == warehouseId);
            warehouse.Deleted=true;
            warehouse.ModDate=System.DateTime.UtcNow;
        }

        public async Task<PagedList<WarehouseDto>> GetWarehouses(string code, Pagination pagination = null)
        {
            var query=context.Warehouses.AsQueryable();
            query=query.Where(x=>!x.Deleted);
            if(!string.IsNullOrEmpty(code)) query=query.Where(x=>x.Code.ToUpper().Contains(code.ToUpper()));
            query = query.OrderBy(x=>x.Code);
            return await PagedList<WarehouseDto>.CreateAsync(
                query.ProjectTo<WarehouseDto>(mapper.ConfigurationProvider).AsNoTracking()
                ,pagination.Page,pagination.ItemsPerPage);
        }

        public async Task<List<Warehouse>> GetWarehouses()
        {
            return await context.Warehouses.ToListAsync();
        }

        public async Task<Warehouse> GetWarehouse(int id)
        {
            return await context.Warehouses
            .FirstOrDefaultAsync(x=>x.Id == id);
        }

        public async Task<Warehouse> GetWarehouseByCode(string code)
        {
            return await context.Warehouses.FirstOrDefaultAsync(x=>x.Code.ToUpper() == code.ToUpper() && !x.Deleted);
        }



        public async void UpdateWarehouse(Warehouse warehouse)
        {
            var w = await  context.Warehouses.FirstOrDefaultAsync(x=>x.Id == warehouse.Id);
            w.Label=warehouse.Label;
            w.Deleted=warehouse.Deleted;
            w.ModDate=System.DateTime.UtcNow;
        }
    }
}