using System.Threading.Tasks;
using API.DBAccess.Entities;

namespace API.Services.Interfaces
{
    public interface ITokenService
    {
        Task<string> CreateToken(AppUser user);
    }
}