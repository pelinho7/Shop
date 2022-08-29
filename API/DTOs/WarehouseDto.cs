using System;

namespace API.DTOs
{
    public class WarehouseDto
    {
        public int Id { get; set; }
        public string Code { get; set; }
        public string Label{get;set;}
        public bool Deleted { get; set; }
        public DateTime ModDate { get; set; }
    }
}