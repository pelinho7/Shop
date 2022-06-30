using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace API.DBAccess.Entities
{
    [Table("CategoryAttributeHistories")]
    public class CategoryAttributeHistory
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
        public Attribute Attribute { get; set; }
        public CategoryAttribute CategoryAttribute{get;set;}
        [Required]
        public int CategoryAttributeId{get;set;}
        

        [NotMapped]
        [DisplayName("Attribute Code")]
        public string AttributeCode { get{ return Attribute?.Code;}  }
    }
}