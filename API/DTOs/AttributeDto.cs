using System;

namespace API.DTOs
{
    public class AttributeDto:AttributeBasicDto
    {
        public string Label{get;set;}
        public int Type { get; set; }
        public int DecimalPlaces { get; set; }
        public int FiltrationMode { get; set; }
        public bool Deleted { get; set; }
        public DateTime ModDate { get; set; }
    }
}