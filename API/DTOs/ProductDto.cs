using System.Collections.Generic;

namespace API.DTOs
{
    public class ProductDto
    {
        public int Id { get; set; }
        public string Code { get; set; }="";
        public string Name { get; set; }="";
        public int CategoryId { get; set; }
        public List<PhotoDto> Photos { get; set; }=new List<PhotoDto>();
        public string Description { get; set; }="";
        public List<ProductAmountDto> ProductAmounts { get; set; }

    }
}