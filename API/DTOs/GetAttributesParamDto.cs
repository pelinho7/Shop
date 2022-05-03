namespace API.DTOs
{
    public class GetAttributesParamDto
    {
        public string Code { get; set; }
        public int? Type { get; set; }
        public int? Page { get; set; }
        public int? ItemsPerPage { get; set; }
    }
}