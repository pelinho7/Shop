using API.DBAccess.Entities;
using API.DBAccess.Interfaces;
using AutoMapper;
using Microsoft.EntityFrameworkCore;

namespace API.DBAccess.Data
{
    public class OpinionLikeRepository : IOpinionLikeRepository
    {
        private readonly DataContext context;
        private readonly IMapper mapper;
        public OpinionLikeRepository(DataContext context, IMapper mapper)
        {
            this.context = context;
            this.mapper = mapper;
        }

        public void AddLikeOpinion(OpinionLike opinionLike)
        {
            opinionLike.CreateDate=System.DateTime.UtcNow;
            context.OpinionLikes.Add(opinionLike);
        }

        public async void DeleteOpinionLike(int opinionLikeId)
        {
            var opinionLike = await context.OpinionLikes.FirstOrDefaultAsync(x => x.Id == opinionLikeId);
            context.OpinionLikes.Remove(opinionLike);
        }
    }
}