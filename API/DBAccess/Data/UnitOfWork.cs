using System;
using System.Threading.Tasks;
using API.DBAccess.Interfaces;
using AutoMapper;
using Microsoft.EntityFrameworkCore.Storage;
using Microsoft.Extensions.Logging;

namespace API.DBAccess.Data
{
    public class UnitOfWork : IUnitOfWork,IDisposable
    {
        private readonly DataContext context;
        private readonly IMapper mapper;
        private readonly ILogger<UnitOfWork> logger;

        public UnitOfWork(DataContext context, IMapper mapper,ILogger<UnitOfWork> logger)
        {
            this.context = context;
            this.mapper = mapper;
            this.logger = logger;
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

        public IProductRepository ProductRepository => new ProductRepository(context, mapper,logger);

        public IPhotoRepository PhotoRepository => new PhotoRepository(context, mapper);

        public IProductHistoryRepository ProductHistoryRepository => new ProductHistoryRepository(context, mapper);
        public IPhotoHistoryRepository PhotoHistoryRepository => new PhotoHistoryRepository(context, mapper);
        public IWarehouseRepository WarehouseRepository => new WarehouseRepository(context, mapper);
        public IProductAmountRepository ProductAmountRepository => new ProductAmountRepository(context, mapper);
        public IDiscountRepository DiscountRepository => new DiscountRepository(context, mapper);
        public IProductTextAttributeRepository ProductTextAttributeRepository => new ProductTextAttributeRepository(context, mapper);
        public IProductNumberAttributeRepository ProductNumberAttributeRepository => new ProductNumberAttributeRepository(context, mapper);
        public IProductNumberAttributeHistoryRepository ProductNumberAttributeHistoryRepository => new ProductNumberAttributeHistoryRepository(context, mapper);
        public IProductTextAttributeHistoryRepository ProductTextAttributeHistoryRepository => new ProductTextAttributeHistoryRepository(context, mapper);
        public IOpinionRepository OpinionRepository => new OpinionRepository(context, mapper);
        public IOpinionLikeRepository OpinionLikeRepository => new OpinionLikeRepository(context, mapper);
        public ICartRepository CartRepository => new CartRepository(context, mapper);
        public ICartLineRepository CartLineRepository => new CartLineRepository(context, mapper);

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