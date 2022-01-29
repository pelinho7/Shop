using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using API.DBAccess.Entities;
using API.DBAccess.Interfaces;
using API.DTOs;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using Microsoft.EntityFrameworkCore;

namespace API.DBAccess.Data
{
    public class UserAgreementRepository:IUserAgreementRepository
    {
        private readonly DataContext context;
        private readonly IMapper mapper;
        private readonly IUserAgreementHistoryRepository userAgreementHistoryRepository;

        public UserAgreementRepository(DataContext context, IMapper mapper
        ,IUserAgreementHistoryRepository userAgreementHistoryRepository)
        {
            this.context = context;
            this.mapper = mapper;
            this.userAgreementHistoryRepository = userAgreementHistoryRepository;
        }

        public void AddUserAgreement(UserAgreement userAgreement)
        {
            context.UserAgreements.Add(userAgreement);
            userAgreementHistoryRepository.AddUserAgreementHistory(userAgreement);
        }

        public async Task<List<UserAgreementDto>> GetUserAgreementsAsync(int userId, bool? obligatory=null)
        {
            var query = context.UserAgreements
            .Where(x=>x.AppUserId == userId)
            .Include(x=>x.Agreement)
            .AsQueryable();

            if(obligatory.HasValue){
                query = query.Where(x=>x.Agreement.Obligatory == obligatory.Value).AsQueryable();
            }

            return await query
            .ProjectTo<UserAgreementDto>(mapper.ConfigurationProvider)
            .ToListAsync();
        }

        public void Update(int id, bool value)
        {
            var agreementToUpdate = context.UserAgreements.FirstOrDefault(x=>x.Id==id);
            agreementToUpdate.Value=value;
            agreementToUpdate.ModDate=System.DateTime.UtcNow;
            userAgreementHistoryRepository.AddUserAgreementHistory(agreementToUpdate);
        }
    }
}