using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore.Storage;

namespace API.DBAccess.Interfaces
{
    public interface IUnitOfWork
    {
        IUserRepository UserRepository{get;}
        IUserHistoryRepository UserHistoryRepository{get;}
        IAgreementRepository AgreementRepository{get;}
        IUserAgreementRepository UserAgreementRepository{get;}
        IUserAgreementHistoryRepository UserAgreementHistoryRepository{get;}
        IShippingAddressRepository ShippingAddressRepository{get;}
        IShippingAddressHistoryRepository ShippingAddressHistoryRepository{get;}
        IAttributeRepository AttributeRepository{get;}
        IAttributeHistoryRepository AttributeHistoryRepository{get;}
        ICategoryRepository CategoryRepository{get;}
        ICategoryHistoryRepository CategoryHistoryRepository{get;}
        ICategoryAttributeRepository CategoryAttributeRepository{get;}
        ICategoryAttributeHistoryRepository CategoryAttributeHistoryRepository{get;}
        ICategoryLinkRepository CategoryLinkRepository{get;}
        IProductRepository ProductRepository{get;}
        IPhotoRepository PhotoRepository{get;}
        IProductHistoryRepository ProductHistoryRepository{get;}
        IPhotoHistoryRepository PhotoHistoryRepository{get;}
        IWarehouseRepository WarehouseRepository{get;}
        IProductAmountRepository ProductAmountRepository{get;}
        IDiscountRepository DiscountRepository{get;}
        IProductTextAttributeRepository ProductTextAttributeRepository{get;}
        IProductNumberAttributeRepository ProductNumberAttributeRepository{get;}
        IProductNumberAttributeHistoryRepository ProductNumberAttributeHistoryRepository{get;}
        IProductTextAttributeHistoryRepository ProductTextAttributeHistoryRepository{get;}
        IOpinionRepository OpinionRepository{get;}
        IOpinionLikeRepository OpinionLikeRepository{get;}
        ICartRepository CartRepository{get;}
        ICartLineRepository CartLineRepository{get;}
        
        Task<bool> Complete();
        Task<IDbContextTransaction> BeginTransaction();
        bool HasChanges();
    }
}