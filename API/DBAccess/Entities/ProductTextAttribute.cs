using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace API.DBAccess.Entities
{
    public class ProductTextAttribute:ProductAttribute
    {
        public string Value { get; set; }
        [Required]
        public DateTime CreateDate { get; set; }

        public ICollection<ProductTextAttributeHistory> ProductTextAttributeHistories { get; set; }
    }
}