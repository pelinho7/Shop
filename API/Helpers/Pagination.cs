namespace API.Helpers
{
    public class Pagination
    {
        private const int MaxPageSize=50;
        public int Page { get; set; }=1;
        public int TotalPages { get; set; }=1;
        public int ItemsPerPage { get; set; }=10;

    //         currentPage:number;
    // itemsPerPage:number;
    // totalItems:number;
    // totalPages:number;
        private int _pageSize=10;

        public int PageSize {
            get=>_pageSize;
            set=>_pageSize=(value>MaxPageSize)?MaxPageSize:value;
        }
    }
}