namespace API.DTOs
{
    public class GetOpinionsParamDto
    {
        public int ProductId { get; set; }
        public int? Page { get; set; }
        public int? ItemsPerPage { get; set; }
        public int SortingType { get; set; }
    }
}