using System;

namespace API.DTOs
{
    public class AgreementDto
    {
        public int Id { get; set; }
        public int? Type { get; set; }
        public string Contents{get;set;}
        public bool Checked { get; set; }
        public bool Obligatory { get; set; }
        public bool Removable { get; set; }=true;
        public DateTime ModDate { get; set; }=DateTime.UtcNow;
    }
}