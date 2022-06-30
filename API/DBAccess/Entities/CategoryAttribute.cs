using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace API.DBAccess.Entities
{
    public class CategoryAttribute
    {
        public int Id { get; set; }
        [Required]
        public int Lp { get; set; }
        [Required]
        public int CategoryId { get; set; }
        [Required]
        public int AttributeId { get; set; }
        public bool Deleted { get; set; }
        [Required]
        public DateTime ModDate { get; set; }
        public Category Category { get; set; }
        public Attribute Attribute { get; set; }
        public ICollection<CategoryAttributeHistory> CategoryAttributeHistories { get; set; }

        [NotMapped]
        public string Code { get{ return Attribute?.Code;}  }
    }
}