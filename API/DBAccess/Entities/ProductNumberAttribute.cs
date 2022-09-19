using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace API.DBAccess.Entities
{
    public class ProductNumberAttribute:ProductAttribute
    {
        public decimal Value { get; set; }
        [Required]
        public DateTime CreateDate { get; set; }

        public ICollection<ProductNumberAttributeHistory> ProductNumberAttributeHistories { get; set; }
    }
}