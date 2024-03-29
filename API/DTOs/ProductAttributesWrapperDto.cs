using System.Collections.Generic;

namespace API.DTOs
{
    public class ProductAttributesWrapperDto
    {
        public List<ProductAttributeOrderDto> ProductAttributeOrders { get; set; }
        public List<ProductTextAttributeDto> ProductTextAttributes { get; set; }
        public List<ProductNumberAttributeDto> ProductNumberAttributes { get; set; }

    }
}