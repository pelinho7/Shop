namespace API.DTOs
{
    public class CategoryAttributeDto
    {
        public int Id { get; set; }
        public int CategoryId { get; set; }
        public int AttributeId { get; set; }
        public int Lp { get; set; }
        public string Code { get; set; }
    }
}