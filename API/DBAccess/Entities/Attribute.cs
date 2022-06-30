using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace API.DBAccess.Entities
{
    public class Attribute
    {
        [Required]
        public int Id { get; set; }
        [Required]
        [MaxLength(30)]
        public string Code { get; set; }
        [Required]
        [MaxLength(60)]
        public string Label{get;set;}
        [Required]
        public int Type { get; set; }
        [Required]
        public int FiltrationMode { get; set; }
        [Required]
        public int DecimalPlaces { get; set; }
        public bool Deleted { get; set; }
        [Required]
        public DateTime ModDate { get; set; }
        public ICollection<AttributeHistory> AttributeHistories { get; set; }
        public CategoryAttribute CategoryAttribute { get; set; }
        public List<CategoryAttributeHistory> CategoryAttributeHistories { get; set; }
    }
}