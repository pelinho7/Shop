using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace API.DBAccess.Entities
{
    public class Category
    {
        public int Id { get; set; }
        [Required]
        [MaxLength(30)]
        public string Code { get; set; }
        [Required]
        [MaxLength(60)]
        public string Label{get;set;}
        public bool Deleted { get; set; }
        [Required]
        public DateTime ModDate { get; set; }
        public int? ParentCategoryId {get;set;}
        public Category ParentCategory { get; set; }
        public ICollection<CategoryLink> CategoryLinks { get; set; }
        public ICollection<CategoryLink> ParentCategoryLinks { get; set; }
        public ICollection<CategoryAttribute> CategoryAttributes { get; set; }
        public ICollection<CategoryHistory> CategoryHistories { get; set; }
        public ICollection<Discount> Discounts { get; set; }
        public ICollection<Product> Products { get; set; }
        public ICollection<ProductHistory> ProductHistories { get; set; }

        [NotMapped]
        public List<CategoryAttribute> ParentCategoriesAttributes { get; set; }
    }
}