using System.Collections.Generic;
using System.Threading.Tasks;
using API.DBAccess.Entities;
using API.Helpers;

namespace API.DBAccess.Interfaces
{
    public interface IOpinionRepository
    {
        void AddOpinion(Opinion opinion);
        Task<PagedList<Opinion>> GetOpinions(int productId,OpinionSortingTypeEnum sortingType, Pagination pagination);
        Task<Opinion> UpdateOpinion(Opinion opinion);
        void DeleteOpinion(int opinionId);
    }
}