namespace API.DTOs
{
    public class ShippingAddressDto
    {
        public int Id { get; set; }
        public int AppUserId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Country { get; set; }
        public string City { get; set; }
        public string ZipCode { get; set; }
        public string Street { get; set; }
        public string BuildingNumber { get; set; }
        public string FlatNumber { get; set; }
        public string Phone { get; set; }
        public bool Deleted { get; set; }
    }
}