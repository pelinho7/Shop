using System.Linq;
using API.DBAccess.Entities;
using API.DTOs;
using AutoMapper;
using Microsoft.AspNetCore.Http;

namespace API.Helpers.AutoMapper
{
    public class CartLinePriceResolver : IValueResolver<CartLine, object, ActualPriceDto>
    {
        private readonly IHttpContextAccessor _contextAccessor;
        private readonly IMapper _mapper;

        public CartLinePriceResolver(IHttpContextAccessor contextAccessor, IMapper mapper)
        {
            _contextAccessor = contextAccessor;
            _mapper = mapper;
        }

        public ActualPriceDto Resolve(CartLine source, object destination, ActualPriceDto destinationMember
        , ResolutionContext context)
        {
            if (source.Product == null || source.Product.Discounts == null)
            {
                return null;
            }
            var discountsDtos = source.Product.Discounts != null ?
            source.Product.Discounts.ToList().Select(x => _mapper.Map<DiscountDto>(x)).ToList()
            : null;
            var actualPriceDto = ActualPriceCalculator.Calculate(discountsDtos, source.Product.Price);


            return actualPriceDto;

            //return new ActualPriceDto();
        }
    }
}