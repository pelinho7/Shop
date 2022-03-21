using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using API.DBAccess.Entities;
using API.DBAccess.Interfaces;
using AutoMapper;
using Microsoft.EntityFrameworkCore;

namespace API.DBAccess.Data
{
    public class ShippingAddressHistoryRepository : IShippingAddressHistoryRepository
    {
        private readonly DataContext context;
        private readonly IMapper mapper;

        public ShippingAddressHistoryRepository(DataContext context, IMapper mapper)
        {
            this.context = context;
            this.mapper = mapper;
        }


        public void AddShippingAddressHistory(ShippingAddress shippingAddress)
        {
            context.ShippingAddressHistories.Add(mapper.Map<ShippingAddress,ShippingAddressHistory>(shippingAddress));
        }

        public async Task<List<ShippingAddressHistory>> GetShippingAddressHistoryByUserAsync(int userId)
        {
            return await context.ShippingAddressHistories.Where(x=>x.AppUserId==userId).ToListAsync();
        }
    }
}