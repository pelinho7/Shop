using System;
using System.Collections.Generic;

namespace API.DBAccess.Entities
{
    public class Agreement
    {
        public int Id { get; set; }
        public int? Type { get; set; }
        public string Contents{get;set;}
        public bool Obligatory { get; set; }
        public bool Removable { get; set; }=true;
        public DateTime ModDate { get; set; }=DateTime.UtcNow;

        public ICollection<UserAgreement> UserAgreements { get; set; }
    }
}