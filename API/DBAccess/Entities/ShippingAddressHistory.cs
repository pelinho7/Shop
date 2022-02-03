using System;
using System.ComponentModel.DataAnnotations;

namespace API.DBAccess.Entities
{
    public class ShippingAddressHistory
    {
        [Required]
        public int Id { get; set; }
        public AppUser AppUser { get; set; }
        [Required]
        public int AppUserId { get; set; }
        [Required]
        public string FirstName { get; set; }
        [Required]
        public string LastName { get; set; }
        [Required]
        public string Country { get; set; }
        [Required]
        public string City { get; set; }
        [Required]
        public string ZipCode { get; set; }
        public string Street { get; set; }
        [Required]
        public string BuildingNumber { get; set; }
        public string FlatNumber { get; set; }
        [Required]
        public string Phone { get; set; }
        public bool Deleted { get; set; }
        public bool Default { get; set; }=false;
        public DateTime ModDate { get; set; }
        public ShippingAddress ShippingAddress{get;set;}
        [Required]
        public int ShippingAddressId{get;set;}
    }
}