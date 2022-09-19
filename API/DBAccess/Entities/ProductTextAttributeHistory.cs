namespace API.DBAccess.Entities
{
    public class ProductTextAttributeHistory:ProductAttribute
    {
        public string Value { get; set; }
        public int ProductTextAttributeId { get; set; }
        public ProductTextAttribute ProductTextAttribute { get; set; }
    }
}