namespace API.DTOs
{
    public class GetWarehousesParamDto
    {
        public string Code { get; set; }
        public int? Page { get; set; }
        public int? ItemsPerPage { get; set; }
    }
}