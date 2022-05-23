using System;
using System.ComponentModel.DataAnnotations;

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
    }
}