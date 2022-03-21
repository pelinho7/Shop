using System;
using System.ComponentModel;
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
        [DisplayName("First Name")]
        public string FirstName { get; set; }
        [Required]
        [DisplayName("Last Name")]
        public string LastName { get; set; }
        [Required]
        [DisplayName("Country")]
        public string Country { get; set; }
        [Required]
        [DisplayName("City")]
        public string City { get; set; }
        [Required]
        [DisplayName("Zip code")]
        public string ZipCode { get; set; }
        [DisplayName("Street")]
        public string Street { get; set; }
        [Required]
        [DisplayName("Building Number")]
        public string BuildingNumber { get; set; }
        [DisplayName("Flat Number")]
        public string FlatNumber { get; set; }
        [Required]
        [DisplayName("Phone")]
        public string Phone { get; set; }
        public bool Deleted { get; set; }
        [DisplayName("Default")]
        public bool Default { get; set; }=false;
        public DateTime ModDate { get; set; }
        public ShippingAddress ShippingAddress{get;set;}
        [Required]
        public int ShippingAddressId{get;set;}
    }
}