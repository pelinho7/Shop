using System;
using System.ComponentModel.DataAnnotations;

namespace API.DBAccess.Entities
{
    public class Opinion
    {
        public int Id { get; set; }
        public int Rating { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }
        public AppUser AppUser { get; set; }
        public int AppUserId { get; set; }
        public int ProductId { get; set; }
        public Product Product { get; set; }
        public bool Deleted { get; set; }
        [Required]
        public DateTime CreateDate { get; set; }
        [Required]
        public DateTime ModDate { get; set; }
    }
}