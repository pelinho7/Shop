using API.DBAccess.Entities;

namespace API.DBAccess.Interfaces
{
    public interface IOpinionLikeRepository
    {
        void AddLikeOpinion(OpinionLike opinionLike);
        void DeleteOpinionLike(int opinionLikeId);
    }
}