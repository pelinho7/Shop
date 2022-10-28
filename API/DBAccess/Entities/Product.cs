using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;

namespace API.DBAccess.Entities
{
    public class Product
    {
        public int Id { get; set; }
        [MaxLength(30)]
        public string Code { get; set; }
        [MaxLength(60)]
        public string Name{get;set;}
        public bool Deleted { get; set; }
        public bool Temporary { get; set; }
        public double Price { get; set; }
        public int? CategoryId { get; set; }
        public string Description{get;set;}
        [Required]
        public DateTime CreateDate { get; set; }
        [Required]
        public DateTime ModDate { get; set; }

        public ICollection<Photo> Photos { get; set; }
        public ICollection<PhotoHistory> PhotoHistories { get; set; }
        public ICollection<ProductHistory> ProductHistories { get; set; }
        public ICollection<ProductAmount> ProductAmounts { get; set; }
        public ICollection<Discount> Discounts { get; set; }
        public Category Category { get; set; }
        public ICollection<ProductTextAttribute> ProductTextAttributes { get; set; }
        public ICollection<ProductNumberAttribute> ProductNumberAttributes { get; set; }
        public ICollection<ProductTextAttributeHistory> ProductTextAttributeHistories { get; set; }
        public ICollection<ProductNumberAttributeHistory> ProductNumberAttributeHistories { get; set; }
        public ICollection<Opinion> Opinions { get; set; }

        // [NotMapped]
        // public double ActualPrice {
        //     get{
        //         if(Discounts == null || !Discounts.Any()) return 9999;
        //         else if
        //     }
        // }
    }
}