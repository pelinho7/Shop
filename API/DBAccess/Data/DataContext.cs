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

        public DbSet<AppUserHistory> UserHistories { get; set; }
        public DbSet<Agreement> Agreements { get; set; }
        public DbSet<UserAgreement> UserAgreements { get; set; }
        public DbSet<UserAgreementHistory> UserAgreementHistories { get; set; }
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

            builder.Entity<UserAgreementHistory>()
                .HasOne(s => s.AppUser)
                .WithMany(l => l.UserAgreementHistories)
                .HasForeignKey(s => s.AppUserId)
                .OnDelete(DeleteBehavior.Cascade);

            builder.Entity<UserAgreementHistory>()
                .HasOne(s => s.Agreement)
                .WithMany(l => l.UserAgreementHistories)
                .HasForeignKey(s => s.AgreementId)
                .OnDelete(DeleteBehavior.Cascade);

            builder.Entity<AppUserHistory>()
                .HasOne(s => s.AppUser)
                .WithMany(l => l.AppUserHistories)
                .HasForeignKey(s => s.AppUserId)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
