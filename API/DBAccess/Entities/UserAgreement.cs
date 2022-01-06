using System;

namespace API.DBAccess.Entities
{
    public class UserAgreement
    {
        public int Id { get; set; }
        public AppUser AppUser { get; set; }
        public int AppUserId { get; set; }
        public Agreement Agreement { get; set; }
        public int AgreementId { get; set; }
        public bool Value { get; set; }
        public DateTime ModDate { get; set; }=DateTime.UtcNow;
    }
}