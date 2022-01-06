using System.Threading.Tasks;

namespace API.DBAccess.Interfaces
{
    public interface IUnitOfWork
    {
        IUserRepository UserRepository{get;}
        IAgreementRepository AgreementRepository{get;}
        Task<bool> Complete();
        bool HasChanges();
    }
}