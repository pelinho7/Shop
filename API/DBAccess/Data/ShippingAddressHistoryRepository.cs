using API.DBAccess.Entities;
using API.DBAccess.Interfaces;
using AutoMapper;

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
    }
}