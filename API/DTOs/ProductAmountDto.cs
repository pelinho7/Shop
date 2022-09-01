using System;

namespace API.DTOs
{
    public class ProductAmountDto
    {
        public int Id { get; set; }
        public string Code { get; set; }
        public string Label{get;set;}
        public int ProductId { get; set; }
        public int WarehouseId { get; set; }
        public double Amount { get; set; }
    }
}