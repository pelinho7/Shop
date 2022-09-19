using System.Collections.Generic;

namespace API.DTOs
{
    public class UpsertProductDto:ProductDto
    {
        public List<ProductAmountDto> ProductAmounts { get; set; }
        public List<DiscountDto> ProductDiscounts { get; set; }
        public List<ProductTextAttributeDto> TextAttributes { get; set; }
        public List<ProductNumberAttributeDto> NumberAttributes { get; set; }

    }
}