using System.Collections.Generic;

namespace API.DTOs
{
    public class ProductDto:ProductBasicDto
    {
        public List<PhotoDto> Photos { get; set; }=new List<PhotoDto>();
        public string Description { get; set; }="";
    }
}