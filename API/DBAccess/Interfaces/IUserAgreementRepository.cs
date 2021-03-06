using System.Collections.Generic;
using System.Threading.Tasks;
using API.DBAccess.Data;
using API.DBAccess.Entities;
using API.DTOs;

namespace API.DBAccess.Interfaces
{
    public interface IUserAgreementRepository
    {
        void AddUserAgreement(UserAgreement userAgreement);
        Task<List<UserAgreementDto>> GetUserAgreementsAsync(int userId, bool? obligatory=null);
        void Update(int id, bool value);
    }
}