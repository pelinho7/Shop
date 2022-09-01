using System.Collections.Generic;
using System.Threading.Tasks;
using API.DBAccess.Data;
using API.DBAccess.Entities;
using API.DTOs;
using API.Helpers;

namespace API.DBAccess.Interfaces
{
    public interface IWarehouseRepository
    {
        void AddWarehouse(Warehouse warehouse);
        void UpdateWarehouse(Warehouse warehouse);
        Task<Warehouse> GetWarehouse(int id);
        Task<PagedList<WarehouseDto>> GetWarehouses(string code, Pagination pagination = null);
        Task<List<Warehouse>> GetWarehouses();
        Task<Warehouse> GetWarehouseByCode(string code);
        void DeleteWarehouse(int warehouseId);
    }
}