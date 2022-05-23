namespace API.DBAccess.Entities
{
    public class CategoryLink
    {
        public int Id { get; set; }
        public int CategoryId { get; set; }
        public int ParentCategoryId { get; set; }
        public Category Category { get; set; }
        public Category ParentCategory { get; set; }
    }
}