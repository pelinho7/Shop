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
        public DbSet<ShippingAddress> ShippingAddresses { get; set; }
        public DbSet<ShippingAddressHistory> ShippingAddressHistories { get; set; }
        public DbSet<Entities.Attribute> Attributes { get; set; }
        public DbSet<AttributeHistory> AttributeHistories { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<CategoryLink> CategoryLinks { get; set; }
        public DbSet<CategoryAttribute> CategoryAttributes { get; set; }
        public DbSet<CategoryHistory> CategoryHistories { get; set; }
        public DbSet<CategoryAttributeHistory> CategoryAttributeHistories { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Photo> Photos { get; set; }
        public DbSet<ProductHistory> ProductHistories { get; set; }
        public DbSet<PhotoHistory> PhotoHistories { get; set; }
        public DbSet<Warehouse> Warehouses { get; set; }


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

            builder.Entity<ShippingAddress>()
                .HasOne(s => s.AppUser)
                .WithMany(l => l.ShippingAddresses)
                .HasForeignKey(s => s.AppUserId)
                .OnDelete(DeleteBehavior.Cascade);

            builder.Entity<ShippingAddressHistory>()
                .HasOne(s => s.AppUser)
                .WithMany(l => l.ShippingAddressHistories)
                .HasForeignKey(s => s.AppUserId)
                .OnDelete(DeleteBehavior.Cascade);

            builder.Entity<ShippingAddressHistory>()
                .HasOne(s => s.ShippingAddress)
                .WithMany(l => l.ShippingAddressHistories)
                .HasForeignKey(s => s.ShippingAddressId)
                .OnDelete(DeleteBehavior.Cascade);

            builder.Entity<AttributeHistory>()
                .HasOne(s => s.Attribute)
                .WithMany(l => l.AttributeHistories)
                .HasForeignKey(s => s.AttributeId)
                .OnDelete(DeleteBehavior.Cascade);

            builder.Entity<CategoryLink>()
                .HasOne(s => s.Category)
                .WithMany(l => l.CategoryLinks)
                .HasForeignKey(s => s.CategoryId)
                .OnDelete(DeleteBehavior.Cascade);

            builder.Entity<CategoryLink>()
                .HasOne(s => s.ParentCategory)
                .WithMany(l => l.ParentCategoryLinks)
                .HasForeignKey(s => s.ParentCategoryId)
                .OnDelete(DeleteBehavior.Cascade);

            builder.Entity<CategoryAttribute>()
                .HasOne(s => s.Category)
                .WithMany(l => l.CategoryAttributes)
                .HasForeignKey(s => s.CategoryId)
                .OnDelete(DeleteBehavior.Cascade);

            builder.Entity<CategoryAttribute>()
                .HasOne(s => s.Attribute)
                .WithOne(l => l.CategoryAttribute)
                .HasForeignKey<CategoryAttribute>(b => b.AttributeId)
                .OnDelete(DeleteBehavior.Cascade);

            builder.Entity<Category>()
                .HasOne(b=>b.ParentCategory)
                .WithMany()
                .HasForeignKey(b=>b.ParentCategoryId);

            builder.Entity<CategoryHistory>()
                .HasOne(s => s.Category)
                .WithMany(l => l.CategoryHistories)
                .HasForeignKey(s => s.CategoryId)
                .OnDelete(DeleteBehavior.Cascade);

            builder.Entity<CategoryAttributeHistory>()
                .HasOne(s => s.CategoryAttribute)
                .WithMany(l => l.CategoryAttributeHistories)
                .HasForeignKey(s => s.CategoryAttributeId)
                .OnDelete(DeleteBehavior.Cascade);

            builder.Entity<CategoryAttributeHistory>()
                .HasOne(s => s.Attribute)
                .WithMany(l => l.CategoryAttributeHistories)
                .HasForeignKey(s => s.AttributeId)
                .OnDelete(DeleteBehavior.Cascade);


            builder.Entity<Photo>()
                .HasOne(s => s.Product)
                .WithMany(l => l.Photos)
                .HasForeignKey(s => s.ProductId)
                .OnDelete(DeleteBehavior.Cascade);

            builder.Entity<ProductHistory>()
                .HasOne(s => s.Product)
                .WithMany(l => l.ProductHistories)
                .HasForeignKey(s => s.ProductId)
                .OnDelete(DeleteBehavior.Cascade);

            builder.Entity<PhotoHistory>()
                .HasOne(s => s.Photo)
                .WithMany(l => l.PhotoHistories)
                .HasForeignKey(s => s.PhotoId)
                .OnDelete(DeleteBehavior.Cascade);

            builder.Entity<PhotoHistory>()
                .HasOne(s => s.Product)
                .WithMany(l => l.PhotoHistories)
                .HasForeignKey(s => s.ProductId)
                .OnDelete(DeleteBehavior.Cascade);



            //default values
            builder.Entity<AppUserHistory>()
                .Property(t=> t.ModDate).HasDefaultValue(DateTime.UtcNow);

            builder.Entity<Agreement>()
                .Property(t=> t.ModDate).HasDefaultValue(DateTime.UtcNow);

            builder.Entity<UserAgreement>()
                .Property(t=> t.ModDate).HasDefaultValue(DateTime.UtcNow);

            builder.Entity<UserAgreementHistory>()
                .Property(t=> t.ModDate).HasDefaultValue(DateTime.UtcNow);

            builder.Entity<ShippingAddress>()
                .Property(t=> t.ModDate).HasDefaultValue(DateTime.UtcNow);

            builder.Entity<ShippingAddressHistory>()
                .Property(t=> t.ModDate).HasDefaultValue(DateTime.UtcNow);

            builder.Entity<Entities.Attribute>()
                .Property(t=> t.ModDate).HasDefaultValue(DateTime.UtcNow);

            builder.Entity<AttributeHistory>()
                .Property(t=> t.ModDate).HasDefaultValue(DateTime.UtcNow);

            builder.Entity<Category>()
                .Property(t=> t.ModDate).HasDefaultValue(DateTime.UtcNow);
            
            builder.Entity<CategoryAttribute>()
                .Property(t=> t.ModDate).HasDefaultValue(DateTime.UtcNow);

            builder.Entity<CategoryHistory>()
                .Property(t=> t.ModDate).HasDefaultValue(DateTime.UtcNow);

            builder.Entity<CategoryAttributeHistory>()
                .Property(t=> t.ModDate).HasDefaultValue(DateTime.UtcNow);

            builder.Entity<Warehouse>()
                .Property(t=> t.ModDate).HasDefaultValue(DateTime.UtcNow);
        }
    }
}
