using System.Collections.Generic;

namespace API.DTOs
{
    public class CategoryDto
    {
        public int Id { get; set; }
        public string Code { get; set; }
        public string Label { get; set; }
        public int? ParentCategoryId {get;set;}
        public bool Deleted { get; set; }
        public List<CategoryAttributeDto> CategoryAttributes { get; set; }=new List<CategoryAttributeDto>();
        public List<CategoryAttributeDto> ParentCategoriesAttributes { get; set; }=new List<CategoryAttributeDto>();
    }
}