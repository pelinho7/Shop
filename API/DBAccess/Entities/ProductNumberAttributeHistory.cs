namespace API.DBAccess.Entities
{
    public class ProductNumberAttributeHistory:ProductAttribute
    {
        public decimal Value { get; set; }
        public int ProductNumberAttributeId { get; set; }
        public ProductNumberAttribute ProductNumberAttribute { get; set; }
    }
}