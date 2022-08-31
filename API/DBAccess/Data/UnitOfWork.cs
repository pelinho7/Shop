using System;
using System.Threading.Tasks;
using API.DBAccess.Interfaces;
using AutoMapper;
using Microsoft.EntityFrameworkCore.Storage;

namespace API.DBAccess.Data
{
    public class UnitOfWork : IUnitOfWork,IDisposable
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
        
        public IAttributeRepository AttributeRepository => new AttributeRepository(context, mapper,AttributeHistoryRepository);
        public IAttributeHistoryRepository AttributeHistoryRepository => new AttributeHistoryRepository(context, mapper);
        
        public ICategoryRepository CategoryRepository => new CategoryRepository(context, mapper,CategoryHistoryRepository);

        public ICategoryHistoryRepository CategoryHistoryRepository => new CategoryHistoryRepository(context, mapper);

        public ICategoryAttributeRepository CategoryAttributeRepository => new CategoryAttributeRepository(context, mapper,CategoryAttributeHistoryRepository);

        public ICategoryAttributeHistoryRepository CategoryAttributeHistoryRepository => new CategoryAttributeHistoryRepository(context, mapper);

        public ICategoryLinkRepository CategoryLinkRepository => new CategoryLinkRepository(context, mapper);

        public IProductRepository ProductRepository => new ProductRepository(context, mapper);

        public IPhotoRepository PhotoRepository => new PhotoRepository(context, mapper);

        public IProductHistoryRepository ProductHistoryRepository => new ProductHistoryRepository(context, mapper);
        public IPhotoHistoryRepository PhotoHistoryRepository => new PhotoHistoryRepository(context, mapper);
        public IWarehouseRepository WarehouseRepository => new WarehouseRepository(context, mapper);

        public async Task<bool> Complete()
        {
            return await context.SaveChangesAsync() > 0;
        }

        public bool HasChanges()
        {
            return context.ChangeTracker.HasChanges();
        }

        public async Task<IDbContextTransaction> BeginTransaction()
        {
            return await context.Database.BeginTransactionAsync();
        }

        private bool _disposed;
        protected void Dispose(bool disposing)
        {
            if (!this._disposed)
            {
                if (disposing)
                {
                    context.Dispose();
                }
            }
            this._disposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}