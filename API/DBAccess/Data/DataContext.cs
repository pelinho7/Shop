using API.DBAccess.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.DBAccess.Data
{
    public class DataContext : IdentityDbContext<AppUser, AppRole, int
    , IdentityUserClaim<int>, AppUserRole, IdentityUserLogin<int>
    , IdentityRoleClaim<int>, IdentityUserToken<int>>
    {
        public DataContext(DbContextOptions options) : base(options)
        {

        }


        public DbSet<Agreement> Agreements { get; set; }
        // public DbSet<Message> Messages { get; set; }
        // public DbSet<Group> Groups { get; set; }
        // public DbSet<Connection> Connections { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.Entity<AppUser>()
            .HasMany(x => x.UserRoles)
            .WithOne(x => x.User)
            .HasForeignKey(x => x.UserId)
            .IsRequired();

            builder.Entity<AppRole>()
            .HasMany(x => x.UserRoles)
            .WithOne(x => x.Role)
            .HasForeignKey(x => x.RoleId)
            .IsRequired();


            builder.Entity<UserAgreement>()
                .HasOne(s => s.AppUser)
                .WithMany(l => l.UserAgreements)
                .HasForeignKey(s => s.AppUserId)
                .OnDelete(DeleteBehavior.Cascade);

            builder.Entity<UserAgreement>()
                .HasOne(s => s.Agreement)
                .WithMany(l => l.UserAgreements)
                .HasForeignKey(s => s.AgreementId)
                .OnDelete(DeleteBehavior.Cascade);

            // builder.Entity<UserLike>()
            //     .HasOne(s => s.LikeUser)
            //     .WithMany(l => l.LikedByUsers)
            //     .HasForeignKey(s => s.LikeUserId)
            //     .OnDelete(DeleteBehavior.Cascade);

            // builder.Entity<Message>()
            //     .HasOne(u => u.Recipient)
            //     .WithMany(m => m.MessagesRecived)
            //     .OnDelete(DeleteBehavior.Restrict);

            // builder.Entity<Message>()
            //     .HasOne(u => u.Sender)
            //     .WithMany(m => m.MessagesSent)
            //     .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
