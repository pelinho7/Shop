using System.Threading.Tasks;
using API.DBAccess.Interfaces;
using AutoMapper;

namespace API.DBAccess.Data
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly DataContext context;
        private readonly IMapper mapper;

        public UnitOfWork(DataContext context, IMapper mapper)
        {
            this.context = context;
            this.mapper = mapper;
        }
        public IUserRepository UserRepository => new UserRepository(context, mapper);
        public IUserHistoryRepository UserHistoryRepository => new UserHistoryRepository(context, mapper);
        public IAgreementRepository AgreementRepository => new AgreementRepository(context, mapper);
        public IUserAgreementRepository UserAgreementRepository => new UserAgreementRepository(context, mapper,UserAgreementHistoryRepository);
        public IUserAgreementHistoryRepository UserAgreementHistoryRepository => new UserAgreementHistoryRepository(context, mapper);

        public IShippingAddressRepository ShippingAddressRepository => new ShippingAddressRepository(context, mapper,ShippingAddressHistoryRepository);
        public IShippingAddressHistoryRepository ShippingAddressHistoryRepository => new ShippingAddressHistoryRepository(context, mapper);

        public async Task<bool> Complete()
        {
            return await context.SaveChangesAsync() > 0;
        }

        public bool HasChanges()
        {
            return context.ChangeTracker.HasChanges();
        }
    }
}