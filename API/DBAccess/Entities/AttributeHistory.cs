using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace API.DBAccess.Entities
{
    public class AttributeHistory
    {
        [Required]
        public int Id { get; set; }
        [Required]
        [MaxLength(30)]
        [DisplayName("Code")]
        public string Code { get; set; }
        [Required]
        [MaxLength(60)]
        [DisplayName("Label")]
        public string Label{get;set;}
        [Required]
        [DisplayName("Type")]
        public int Type { get; set; }
        [Required]
        [DisplayName("Filtration mode")]
        public int FiltrationMode { get; set; }
        [Required]
        [DisplayName("Decimal places")]
        public int DecimalPlaces { get; set; }
        [Required]
        public bool Deleted { get; set; }
        [Required]
        public DateTime ModDate { get; set; }
        [Required]
        public int AttributeId{get;set;}
        public Attribute Attribute{get;set;}
    }
}