using API.DBAccess.Entities;
using API.DBAccess.Interfaces;
using AutoMapper;

namespace API.DBAccess.Data
{
    public class ProductNumberAttributeHistoryRepository:IProductNumberAttributeHistoryRepository
    {
        private readonly DataContext context;
        private readonly IMapper mapper;
        public ProductNumberAttributeHistoryRepository(DataContext context, IMapper mapper)
        {
            this.context = context;
            this.mapper = mapper;
        }

        public void AddProductNumberAttributeHistory(ProductNumberAttribute productNumberAttribute)
        {
            context.ProductNumberAttributeHistories.Add(mapper.Map<ProductNumberAttribute,ProductNumberAttributeHistory>(productNumberAttribute));
        }
    }
}