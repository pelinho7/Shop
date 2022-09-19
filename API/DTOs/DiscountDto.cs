using System;

namespace API.DTOs
{
    public class DiscountDto
    {
        public int Id { get; set; }
        public int Type { get; set; }
        public double Value { get; set; }
        public int? ProductId { get; set; }
        public int? CategoryId { get; set; }
        public bool Deleted { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
    }
}