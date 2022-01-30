using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using API.DBAccess.Entities;
using API.DBAccess.Interfaces;
using API.DTOs;
using AutoMapper;
using Microsoft.EntityFrameworkCore;

namespace API.DBAccess.Data
{
    public class ShippingAddressRepository : IShippingAddressRepository
    {
        private readonly DataContext context;
        private readonly IMapper mapper;
        private readonly IShippingAddressHistoryRepository shippingAddressHistoryRepository;

        public ShippingAddressRepository(DataContext context, IMapper mapper
        ,IShippingAddressHistoryRepository shippingAddressHistoryRepository)
        {
            this.context = context;
            this.mapper = mapper;
            this.shippingAddressHistoryRepository = shippingAddressHistoryRepository;
        }

        public void AddShippingAddress(ShippingAddress shippingAddress)
        {
            //context.ShippingAddresses.Count(x=>x.)
            context.ShippingAddresses.Add(shippingAddress);
        }

        public async void DeleteShippingAddress(int addressId)
        {
            var address = await context.ShippingAddresses.FirstOrDefaultAsync(x=>x.Id == addressId);
            address.Deleted=true;
            address.ModDate=System.DateTime.UtcNow;
            shippingAddressHistoryRepository.AddShippingAddressHistory(address);
        }

        public async Task<ShippingAddress> GetUserShippingAddressByIdAsync(int addressId)
        {
            return await context.ShippingAddresses
            .FirstOrDefaultAsync(x=>x.Id == addressId && !x.Deleted);
        }

        public async Task<List<ShippingAddressDto>> GetUserShippingAddressesAsync(int userId)
        {
            var shippingAddresses = await context.ShippingAddresses
            .Where(x=>x.AppUserId == userId && !x.Deleted).ToListAsync();
            return mapper.Map<List<ShippingAddressDto>>(shippingAddresses);
        }

        public void MarkAsDefaultAddress(int addressId)
        {
            throw new System.NotImplementedException();
        }

        public void UpdateShippingAddress(ShippingAddress shippingAddress)
        {

            shippingAddressHistoryRepository.AddShippingAddressHistory(shippingAddress);
        }
    }
}