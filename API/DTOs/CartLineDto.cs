using System;
using API.DBAccess.Entities;

namespace API.DTOs
{
    public class CartLineDto
    {
        public int Id { get; set; }
        public double Quantity { get; set; }
        public int ProductId { get; set; }
        public string Name { get; set; }
        public string CartId { get; set; }
        public string PhotoUrl { get; set; }
        public double? Price { get; set; }
        public ActualPriceDto ActualPrice { get; set; }
    }
}