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
            if(context.ShippingAddresses.Count(x=>x.Default && x.AppUserId==shippingAddress.AppUserId) == 0){
                shippingAddress.Default=true;
            }
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

        public async void MarkAsDefaultAddress(int addressId)
        {
            var address = await  context.ShippingAddresses.FirstOrDefaultAsync(x=>x.Id == addressId);
            if(address != null){
                System.DateTime modDate=System.DateTime.UtcNow;
                address.Default=true;
                address.ModDate=modDate;
                shippingAddressHistoryRepository.AddShippingAddressHistory(address);

                var defaultAddress = await context.ShippingAddresses
                .FirstOrDefaultAsync(x=>x.Default  && x.AppUserId==address.AppUserId);

                if(defaultAddress!=null){
                    defaultAddress.Default=false;
                    defaultAddress.ModDate=modDate;
                    shippingAddressHistoryRepository.AddShippingAddressHistory(defaultAddress);
                }
            }
            else{
                throw new System.Exception("Not found");
            }
        }

        public async void UpdateShippingAddress(ShippingAddress shippingAddress)
        {
            var address = await  context.ShippingAddresses.FirstOrDefaultAsync(x=>x.Id == shippingAddress.Id);
            address.FirstName=shippingAddress.FirstName;
            address.LastName=shippingAddress.LastName;
            address.Country=shippingAddress.Country;
            address.City=shippingAddress.City;
            address.ZipCode=shippingAddress.ZipCode;
            address.Street=shippingAddress.Street;
            address.BuildingNumber=shippingAddress.BuildingNumber;
            address.FlatNumber=shippingAddress.FlatNumber;
            address.Phone=shippingAddress.Phone;
            address.ModDate=System.DateTime.UtcNow;
            shippingAddressHistoryRepository.AddShippingAddressHistory(address);
        }
    }
}