using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using API.DBAccess.Entities;
using API.DBAccess.Interfaces;
using API.DTOs;
using AutoMapper;

namespace API.DBAccess.Data
{
    public class UserHistoryRepository : IUserHistoryRepository
    {
        private readonly DataContext context;
        private readonly IMapper mapper;

        public UserHistoryRepository(DataContext context, IMapper mapper)
        {
            this.context = context;
            this.mapper = mapper;
        }

        public void AddUserHistory(AppUser appUser)
        {
            context.UserHistories.Add(mapper.Map<AppUser, AppUserHistory>(appUser));
        }
    }
}