namespace API.DTOs
{
    public class ProductNumberAttributeDto:ProductAttributeDto
    {
        public decimal Value { get; set; }
        public int DecimalPlaces { get; set; }
    }
}