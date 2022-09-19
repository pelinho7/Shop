namespace API.DTOs
{
    public class ProductBasicDto
    {
        public int Id { get; set; }
        public string Code { get; set; }="";
        public string Name { get; set; }="";
        public int CategoryId { get; set; }
        public double Price { get; set; }
    }
}