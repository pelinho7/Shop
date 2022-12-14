using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using API.DBAccess.Entities;
using API.DTOs;
using AutoMapper;
using Microsoft.AspNetCore.Http;

namespace API.Helpers.AutoMapper
{
    public class CurrentUserOpinionLikeResolver : IValueResolver<Opinion, object, OpinionLikeDto>
    {
        private readonly IHttpContextAccessor _contextAccessor;

        public CurrentUserOpinionLikeResolver(IHttpContextAccessor contextAccessor)
        {
            _contextAccessor = contextAccessor;
        }

        public OpinionLikeDto Resolve(Opinion source, object destination, OpinionLikeDto destinationMember
        , ResolutionContext context)
        {
            var userId = _contextAccessor.HttpContext.User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
            if (userId == null) return null;
            var opinionLike = source.OpinionLikes?.FirstOrDefault(x => x.AppUserId == int.Parse(userId));
            return  context.Mapper.Map<OpinionLikeDto>(opinionLike);
        }
    }
}