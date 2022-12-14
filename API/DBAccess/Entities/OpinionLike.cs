using System;
using System.ComponentModel.DataAnnotations;

namespace API.DBAccess.Entities
{
    public class OpinionLike
    {
        public int Id { get; set; }
        public AppUser AppUser { get; set; }
        public int AppUserId { get; set; }
        public int OpinionId { get; set; }
        public Opinion Opinion { get; set; }
        [Required]
        public DateTime CreateDate { get; set; }
    }
}