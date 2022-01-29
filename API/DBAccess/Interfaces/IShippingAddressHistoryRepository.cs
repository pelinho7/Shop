using System.Collections.Generic;
using System.Threading.Tasks;
using API.DBAccess.Data;
using API.DBAccess.Entities;
using API.DTOs;

namespace API.DBAccess.Interfaces
{
    public interface IShippingAddressHistoryRepository
    {
        void AddShippingAddressHistory(ShippingAddress shippingAddress);
    }
}