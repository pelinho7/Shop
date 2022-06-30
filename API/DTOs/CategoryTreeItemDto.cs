using System.Collections.Generic;

namespace API.DTOs
{
    public class CategoryTreeItemDto
    {
        public int Id { get; set; }
        public string Code { get; set; }
        public string Label { get; set; }
        public int? ParentCategoryId {get;set;}
        public bool Deleted { get; set; }
        public bool Visible { get; set; }=false;
        public int TreeLevel { get; set; }
        public List<CategoryTreeItemDto> SubCategories { get; set; }=new List<CategoryTreeItemDto>();
    }
}