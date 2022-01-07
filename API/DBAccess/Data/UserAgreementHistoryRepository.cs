using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using API.DBAccess.Entities;
using API.DBAccess.Interfaces;
using API.DTOs;
using AutoMapper;

namespace API.DBAccess.Data
{
    public class UserAgreementHistoryRepository:IUserAgreementHistoryRepository
    {
        private readonly DataContext context;
        private readonly IMapper mapper;

        public UserAgreementHistoryRepository(DataContext context, IMapper mapper)
        {
            this.context = context;
            this.mapper = mapper;
        }

        public void AddUserAgreementHistory(UserAgreement userAgreement)
        {
            context.UserAgreementHistories.Add(mapper.Map<UserAgreement,UserAgreementHistory>(userAgreement));
        }
    }
}