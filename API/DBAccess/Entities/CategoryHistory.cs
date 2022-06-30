using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace API.DBAccess.Entities
{
    public class CategoryHistory
    {
        public int Id { get; set; }
        [Required]
        [MaxLength(30)]
        [DisplayName("Code")]
        public string Code { get; set; }
        [Required]
        [MaxLength(60)]
        [DisplayName("Label")]
        public string Label{get;set;}
        public bool Deleted { get; set; }
        [Required]
        public DateTime ModDate { get; set; }
        public int? ParentCategoryId {get;set;}
        public Category Category{get;set;}
        [Required]
        public int CategoryId{get;set;}
    }
}