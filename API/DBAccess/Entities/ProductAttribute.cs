using System;
using System.ComponentModel.DataAnnotations;

namespace API.DBAccess.Entities
{
    public class ProductAttribute
    {
        public int Id { get; set; }
        [Required]
        public int ProductId { get; set; }
        [Required]
        public int AttributeId { get; set; }
        public bool Deleted { get; set; }
        [Required]
        public DateTime ModDate { get; set; }

        public Product Product { get; set; }
        public Attribute Attribute { get; set; }
    }
}