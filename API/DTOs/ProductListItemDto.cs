using System.Collections.Generic;
using System.Linq;
using API.DBAccess.Entities;
using API.Helpers;

namespace API.DTOs
{
    public class ProductListItemDto : ProductDto
    {
        public string MainPhotoUrl { get; set; }
        public List<DiscountDto> Discounts { get; set; }
        public ActualPriceDto ActualPrice
        {
            get
            {
                return ActualPriceCalculator.Calculate(this.Discounts, this.Price);
            }
        }
    }
}