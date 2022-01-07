using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using API.DBAccess.Entities;
using API.DBAccess.Interfaces;
using API.DTOs;
using AutoMapper;

namespace API.DBAccess.Data
{
    public class UserAgreementRepository:IUserAgreementRepository
    {
        private readonly DataContext context;
        private readonly IMapper mapper;

        public UserAgreementRepository(DataContext context, IMapper mapper)
        {
            this.context = context;
            this.mapper = mapper;
        }

        public void AddUserAgreement(UserAgreement userAgreement)
        {
            context.UserAgreements.Add(userAgreement);
        }
    }
}