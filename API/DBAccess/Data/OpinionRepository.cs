using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using API.DBAccess.Entities;
using API.DBAccess.Interfaces;
using API.Helpers;
using AutoMapper;
using Microsoft.EntityFrameworkCore;

namespace API.DBAccess.Data
{
    public class OpinionRepository : IOpinionRepository
    {
        private readonly DataContext context;
        private readonly IMapper mapper;
        public OpinionRepository(DataContext context, IMapper mapper)
        {
            this.context = context;
            this.mapper = mapper;
        }

        public void AddOpinion(Opinion opinion)
        {
            opinion.CreateDate = System.DateTime.UtcNow;
            opinion.ModDate = opinion.CreateDate;
            context.Opinions.Add(opinion);
        }

        public async void DeleteOpinion(int opinionId)
        {
            var opinion = await context.Opinions.FirstOrDefaultAsync(x => x.Id == opinionId);
            opinion.Deleted = true;
            opinion.ModDate = System.DateTime.UtcNow;
        }

        public async Task<PagedList<Opinion>> GetOpinions(int productId, OpinionSortingTypeEnum sortingType
        , Pagination pagination)
        {
            var query = context.Opinions
            .Include(x => x.AppUser)
            .Include(x => x.OpinionLikes)
            .Where(x => !x.Deleted)
            .AsQueryable();

            if (sortingType == OpinionSortingTypeEnum.FromNewest)
            {
                query = query.OrderByDescending(x => x.CreateDate);
            }
            else if (sortingType == OpinionSortingTypeEnum.FromOldest)
            {
                query = query.OrderBy(x => x.CreateDate);
            }
            else if (sortingType == OpinionSortingTypeEnum.FromMostPopular)
            {
                query = query.OrderByDescending(x => x.OpinionLikes.Count());
            }
            return await PagedList<Opinion>.CreateAsync(
                query.AsNoTracking()
                , pagination.Page, pagination.ItemsPerPage);
        }

        public async Task<Opinion> UpdateOpinion(Opinion opinion)
        {
            var op = await context.Opinions.FirstOrDefaultAsync(x => x.Id == opinion.Id);
            op.Title = opinion.Title;
            op.Content = opinion.Content;
            op.Rating = opinion.Rating;
            op.ModDate = System.DateTime.UtcNow;
            return op;
        }
    }
}