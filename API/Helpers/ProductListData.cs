using System.Collections.Generic;

namespace API.Helpers
{
    public class ProductListData
    {
        public List<FilterAttribute> FilterAttributes{get;set;}
        public Pagination Pagination { get; set; }

        public ProductListData()
        {
        }

        public ProductListData(List<FilterAttribute> filterAttributes, Pagination pagination)
        {
            FilterAttributes = filterAttributes;
            Pagination = pagination;
        }
    }
}