using System.Collections.Generic;
using System.Threading.Tasks;
using API.DBAccess.Data;
using API.DBAccess.Entities;
using API.DTOs;

namespace API.DBAccess.Interfaces
{
    public interface IAgreementRepository
    {
        Task<IEnumerable<AgreementDto>> GetAgreementsByTypeAsync(AgreementTypeEnum agreementType);
        void AddAgreement(Agreement agreement);
        int Count();
    }
}