using System.Collections.Generic;
using System.Threading.Tasks;
using API.DBAccess.Data;
using API.DBAccess.Entities;
using API.DTOs;

namespace API.DBAccess.Interfaces
{
    public interface IShippingAddressRepository
    {
        void AddShippingAddress(ShippingAddress shippingAddress);
        void UpdateShippingAddress(ShippingAddress shippingAddress);
        void DeleteShippingAddress(int addressId);
        void MarkAsDefaultAddress(int addressId);
        Task<List<ShippingAddressDto>> GetUserShippingAddressesAsync(int userId);
        Task<ShippingAddress> GetUserShippingAddressByIdAsync(int addressId);
    }
}