using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using API.DBAccess.Entities;

namespace API.DBAccess.Entities
{
    public class Photo
    {
        public int Id { get; set; }
        public int Lp { get; set; }
        public string Url { get; set;} 
        public string PublicId { get; set; }
        [Required]
        public DateTime ModDate { get; set; }
        public int ProductId { get; set; }
        public bool Deleted { get; set; }

        public Product Product{get;set;}

        public ICollection<PhotoHistory> PhotoHistories { get; set; }
    }
}