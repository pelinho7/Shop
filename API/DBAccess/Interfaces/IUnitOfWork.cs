using System.Threading.Tasks;

namespace API.DBAccess.Interfaces
{
    public interface IUnitOfWork
    {
        IUserRepository UserRepository{get;}
        Task<bool> Complete();
        bool HasChanges();
    }
}