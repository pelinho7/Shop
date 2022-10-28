using System.Collections.Generic;
using API.Helpers;

namespace API.DTOs
{
    public class ProductFullDataDto:ProductDto
    {
        public List<DiscountDto> Discounts { get; set; }
        public List<ProductTextAttributeDto> Parameters { get; set; }
        public ActualPriceDto ActualPrice
        {
            get
            {
                return ActualPriceCalculator.Calculate(this.Discounts, this.Price);
            }
        }
    }
}