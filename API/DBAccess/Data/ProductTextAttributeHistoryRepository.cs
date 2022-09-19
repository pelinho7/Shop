using API.DBAccess.Entities;
using API.DBAccess.Interfaces;
using AutoMapper;

namespace API.DBAccess.Data
{
    public class ProductTextAttributeHistoryRepository:IProductTextAttributeHistoryRepository
    {
        private readonly DataContext context;
        private readonly IMapper mapper;
        public ProductTextAttributeHistoryRepository(DataContext context, IMapper mapper)
        {
            this.context = context;
            this.mapper = mapper;
        }

        public void AddProductTextAttributeHistory(ProductTextAttribute productTextAttribute)
        {
            context.ProductTextAttributeHistories.Add(mapper.Map<ProductTextAttribute,ProductTextAttributeHistory>(productTextAttribute));
        }
    }
}