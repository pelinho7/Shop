using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

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
        [Required]
        public DateTime CreateDate { get; set; }
        [Required]
        public DateTime ModDate { get; set; }

        public ICollection<Photo> Photos { get; set; }
        public ICollection<PhotoHistory> PhotoHistories { get; set; }
        public ICollection<ProductHistory> ProductHistories { get; set; }
    }
}