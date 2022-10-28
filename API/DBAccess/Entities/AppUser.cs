using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;

namespace API.DBAccess.Entities
{
    public class AppUser:IdentityUser<int>
    {   
        public string FirstName { get; set; }
        public string LastName { get; set; }

        // public DateTime DateOfBirth { get; set; }
        // public string KnownAs { get; set; }
        // public DateTime Created { get; set; }=DateTime.Now;
        // public DateTime LastActive { get; set; }=DateTime.Now;
        // public string Gender { get; set; }
        // public string Introduction { get; set; }
        // public string LookingFor { get; set; }
        // public string Interests { get; set; }
        // public string City { get; set; }
        // public string Country { get; set; }
        public ICollection<AppUserRole> UserRoles { get; set; }
        public ICollection<UserAgreement> UserAgreements { get; set; }
        public ICollection<AppUserHistory> AppUserHistories { get; set; }
        public ICollection<UserAgreementHistory> UserAgreementHistories { get; set; }
        public ICollection<ShippingAddress> ShippingAddresses { get; set; }
        public ICollection<ShippingAddressHistory> ShippingAddressHistories { get; set; }
        public ICollection<Opinion> Opinions { get; set; }
    }
}
