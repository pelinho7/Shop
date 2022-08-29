using System;
using System.ComponentModel.DataAnnotations;

namespace API.DBAccess.Entities
{
    public class PhotoHistory
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

        public int PhotoId {get;set;}
        public Photo Photo {get;set;}
    }
}