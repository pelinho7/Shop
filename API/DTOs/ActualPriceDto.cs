using System;

namespace API.DTOs
{
    public class ActualPriceDto
    {
        public double DiscountPrice { get; set; }
        public DateTime DiscountStartDate { get; set; }
        public DateTime DiscountEndDate { get; set; }
    }
}