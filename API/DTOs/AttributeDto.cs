using System;

namespace API.DTOs
{
    public class AttributeDto
    {
        public int Id { get; set; }
        public string Code { get; set; }
        public string Label{get;set;}
        public int Type { get; set; }
        public int DecimalPlaces { get; set; }
        public int FiltrationMode { get; set; }
        public bool Deleted { get; set; }
        public DateTime ModDate { get; set; }
    }
}