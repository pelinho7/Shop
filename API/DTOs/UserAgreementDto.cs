using System;

namespace API.DTOs
{
    public class UserAgreementDto
    {
        public int Id { get; set; }
        public int AgreementId { get; set; }
        public string Contents{get;set;}
        public bool Value { get; set; }
    }
}