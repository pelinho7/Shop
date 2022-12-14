using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using API.DBAccess.Entities;
using API.DTOs;
using AutoMapper;
using Microsoft.AspNetCore.Http;

namespace API.Helpers.AutoMapper
{
    public class CartLinePhotoResolver : IValueResolver<CartLine, object, string>
    {
        private readonly IHttpContextAccessor _contextAccessor;

        public CartLinePhotoResolver(IHttpContextAccessor contextAccessor)
        {
            _contextAccessor = contextAccessor;
        }

        public string Resolve(CartLine source, object destination, string destinationMember
        , ResolutionContext context)
        {
            var photos= source.Product?.Photos;
            var photoUrl = photos?.FirstOrDefault(x=>x.Lp == photos.Min(y=>y.Lp))?.Url;
            return  photoUrl;
        }
    }
}