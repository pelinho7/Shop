using System.Threading.Tasks;

namespace API.DBAccess.Interfaces
{
    public interface IUnitOfWork
    {
        IUserRepository UserRepository{get;}
        IUserHistoryRepository UserHistoryRepository{get;}
        IAgreementRepository AgreementRepository{get;}
        IUserAgreementRepository UserAgreementRepository{get;}
        IUserAgreementHistoryRepository UserAgreementHistoryRepository{get;}
        Task<bool> Complete();
        bool HasChanges();
    }
}