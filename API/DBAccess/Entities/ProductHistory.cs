using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace API.DBAccess.Entities
{
    public class ProductHistory
    {
        public int Id { get; set; }
        [MaxLength(30)]
        public string Code { get; set; }
        [MaxLength(60)]
        public string Name{get;set;}
        public bool Deleted { get; set; }
        [Required]
        public DateTime ModDate { get; set; }
        public int ProductId { get; set; }
        public Product Product{get;set;}

        public ICollection<Photo> Photos { get; set; }
    }
}