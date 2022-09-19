namespace API.DTOs
{
    public class GetProductsManagmentParamDto
    {
        public string Code { get; set; }
        public int? CategoryId { get; set; }
        public int? Page { get; set; }
        public int? ItemsPerPage { get; set; }
    }
}