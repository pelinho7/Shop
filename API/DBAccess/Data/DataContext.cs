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
        public DbSet<ProductAmount> ProductAmounts { get; set; }
        public DbSet<Discount> Discounts { get; set; }
        public DbSet<ProductNumberAttribute> ProductNumberAttributes { get; set; }
        public DbSet<ProductNumberAttributeHistory> ProductNumberAttributeHistories { get; set; }
        public DbSet<ProductTextAttribute> ProductTextAttributes { get; set; }
        public DbSet<ProductTextAttributeHistory> ProductTextAttributeHistories { get; set; }
        public DbSet<Opinion> Opinions { get; set; }
        public DbSet<OpinionLike> OpinionLikes { get; set; }
        public DbSet<Cart> Carts { get; set; }
        public DbSet<CartLine> CartLines { get; set; }

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
                .HasOne(b => b.ParentCategory)
                .WithMany()
                .HasForeignKey(b => b.ParentCategoryId);

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

            builder.Entity<ProductAmount>()
                .HasOne(s => s.Product)
                .WithMany(l => l.ProductAmounts)
                .HasForeignKey(s => s.ProductId)
                .OnDelete(DeleteBehavior.Cascade);

            builder.Entity<ProductAmount>()
                .HasOne(s => s.Warehouse)
                .WithMany(l => l.ProductAmounts)
                .HasForeignKey(s => s.WarehouseId)
                .OnDelete(DeleteBehavior.Cascade);

            builder.Entity<Discount>()
                .HasOne(s => s.Product)
                .WithMany(l => l.Discounts)
                .HasForeignKey(s => s.ProductId)
                .OnDelete(DeleteBehavior.Cascade);

            builder.Entity<Discount>()
                .HasOne(s => s.Category)
                .WithMany(l => l.Discounts)
                .HasForeignKey(s => s.CategoryId)
                .OnDelete(DeleteBehavior.Cascade);

            builder.Entity<Product>()
                .HasOne(s => s.Category)
                .WithMany(l => l.Products)
                .HasForeignKey(s => s.CategoryId)
                .OnDelete(DeleteBehavior.Cascade);

            builder.Entity<ProductHistory>()
                .HasOne(s => s.Category)
                .WithMany(l => l.ProductHistories)
                .HasForeignKey(s => s.CategoryId)
                .OnDelete(DeleteBehavior.Cascade);

            builder.Entity<ProductTextAttribute>()
                .HasOne(s => s.Product)
                .WithMany(l => l.ProductTextAttributes)
                .HasForeignKey(s => s.ProductId)
                .OnDelete(DeleteBehavior.Cascade);

            builder.Entity<ProductTextAttribute>()
                .HasOne(s => s.Attribute)
                .WithMany(l => l.ProductTextAttributes)
                .HasForeignKey(s => s.AttributeId)
                .OnDelete(DeleteBehavior.Cascade);

            builder.Entity<ProductNumberAttribute>()
                .HasOne(s => s.Product)
                .WithMany(l => l.ProductNumberAttributes)
                .HasForeignKey(s => s.ProductId)
                .OnDelete(DeleteBehavior.Cascade);

            builder.Entity<ProductNumberAttribute>()
                .HasOne(s => s.Attribute)
                .WithMany(l => l.ProductNumberAttributes)
                .HasForeignKey(s => s.AttributeId)
                .OnDelete(DeleteBehavior.Cascade);

            builder.Entity<ProductNumberAttributeHistory>()
                .HasOne(s => s.ProductNumberAttribute)
                .WithMany(l => l.ProductNumberAttributeHistories)
                .HasForeignKey(s => s.ProductNumberAttributeId)
                .OnDelete(DeleteBehavior.Cascade);

            builder.Entity<ProductNumberAttributeHistory>()
                .HasOne(s => s.Product)
                .WithMany(l => l.ProductNumberAttributeHistories)
                .HasForeignKey(s => s.ProductId)
                .OnDelete(DeleteBehavior.Cascade);

            builder.Entity<ProductNumberAttributeHistory>()
                .HasOne(s => s.Attribute)
                .WithMany(l => l.ProductNumberAttributeHistories)
                .HasForeignKey(s => s.AttributeId)
                .OnDelete(DeleteBehavior.Cascade);

            builder.Entity<ProductTextAttributeHistory>()
                .HasOne(s => s.ProductTextAttribute)
                .WithMany(l => l.ProductTextAttributeHistories)
                .HasForeignKey(s => s.ProductTextAttributeId)
                .OnDelete(DeleteBehavior.Cascade);

            builder.Entity<ProductTextAttributeHistory>()
                .HasOne(s => s.Product)
                .WithMany(l => l.ProductTextAttributeHistories)
                .HasForeignKey(s => s.ProductId)
                .OnDelete(DeleteBehavior.Cascade);

            builder.Entity<ProductTextAttributeHistory>()
                .HasOne(s => s.Attribute)
                .WithMany(l => l.ProductTextAttributeHistories)
                .HasForeignKey(s => s.AttributeId)
                .OnDelete(DeleteBehavior.Cascade);

            builder.Entity<Opinion>()
                .HasOne(s => s.Product)
                .WithMany(l => l.Opinions)
                .HasForeignKey(s => s.ProductId)
                .OnDelete(DeleteBehavior.Cascade);

            builder.Entity<Opinion>()
                .HasOne(s => s.AppUser)
                .WithMany(l => l.Opinions)
                .HasForeignKey(s => s.AppUserId)
                .OnDelete(DeleteBehavior.Cascade);

            builder.Entity<OpinionLike>()
                .HasOne(s => s.AppUser)
                .WithMany(l => l.OpinionLikes)
                .HasForeignKey(s => s.AppUserId)
                .OnDelete(DeleteBehavior.Cascade);

            builder.Entity<OpinionLike>()
                .HasOne(s => s.Opinion)
                .WithMany(l => l.OpinionLikes)
                .HasForeignKey(s => s.OpinionId)
                .OnDelete(DeleteBehavior.Cascade);

            builder.Entity<CartLine>()
                .HasOne(s => s.Cart)
                .WithMany(l => l.CartLines)
                .HasForeignKey(s => s.CartId)
                .OnDelete(DeleteBehavior.Cascade);

            builder.Entity<CartLine>()
                .HasOne(s => s.Product)
                .WithMany(l => l.CartLines)
                .HasForeignKey(s => s.ProductId)
                .OnDelete(DeleteBehavior.Cascade);
            

            builder.Entity<OpinionLike>()
                .HasIndex(p => new {p.AppUserId , p.OpinionId}).IsUnique();

            //default values
            builder.Entity<AppUserHistory>()
                .Property(t => t.ModDate).HasDefaultValue(DateTime.UtcNow);

            builder.Entity<Agreement>()
                .Property(t => t.ModDate).HasDefaultValue(DateTime.UtcNow);

            builder.Entity<UserAgreement>()
                .Property(t => t.ModDate).HasDefaultValue(DateTime.UtcNow);

            builder.Entity<UserAgreementHistory>()
                .Property(t => t.ModDate).HasDefaultValue(DateTime.UtcNow);

            builder.Entity<ShippingAddress>()
                .Property(t => t.ModDate).HasDefaultValue(DateTime.UtcNow);

            builder.Entity<ShippingAddressHistory>()
                .Property(t => t.ModDate).HasDefaultValue(DateTime.UtcNow);

            builder.Entity<Entities.Attribute>()
                .Property(t => t.ModDate).HasDefaultValue(DateTime.UtcNow);

            builder.Entity<AttributeHistory>()
                .Property(t => t.ModDate).HasDefaultValue(DateTime.UtcNow);

            builder.Entity<Category>()
                .Property(t => t.ModDate).HasDefaultValue(DateTime.UtcNow);

            builder.Entity<CategoryAttribute>()
                .Property(t => t.ModDate).HasDefaultValue(DateTime.UtcNow);

            builder.Entity<CategoryHistory>()
                .Property(t => t.ModDate).HasDefaultValue(DateTime.UtcNow);

            builder.Entity<CategoryAttributeHistory>()
                .Property(t => t.ModDate).HasDefaultValue(DateTime.UtcNow);

            builder.Entity<Warehouse>()
                .Property(t => t.ModDate).HasDefaultValue(DateTime.UtcNow);

            builder.Entity<ProductAmount>()
                .Property(t => t.ModDate).HasDefaultValue(DateTime.UtcNow);

            builder.Entity<Discount>()
                .Property(t => t.ModDate).HasDefaultValue(DateTime.UtcNow);

            builder.Entity<ProductTextAttribute>()
                .Property(t => t.ModDate).HasDefaultValue(DateTime.UtcNow);

            builder.Entity<ProductNumberAttribute>()
                .Property(t => t.ModDate).HasDefaultValue(DateTime.UtcNow);

            builder.Entity<ProductTextAttribute>()
                .Property(t => t.CreateDate).HasDefaultValue(DateTime.UtcNow);

            builder.Entity<ProductNumberAttribute>()
                .Property(t => t.CreateDate).HasDefaultValue(DateTime.UtcNow);

            builder.Entity<ProductTextAttributeHistory>()
                .Property(t => t.ModDate).HasDefaultValue(DateTime.UtcNow);

            builder.Entity<ProductNumberAttributeHistory>()
                .Property(t => t.ModDate).HasDefaultValue(DateTime.UtcNow);

            builder.Entity<Product>()
                .Property(t => t.CreateDate).HasDefaultValue(DateTime.UtcNow);

            builder.Entity<Product>()
                .Property(t => t.ModDate).HasDefaultValue(DateTime.UtcNow);

            builder.Entity<Opinion>()
                .Property(t => t.CreateDate).HasDefaultValue(DateTime.UtcNow);

            builder.Entity<Opinion>()
                .Property(t => t.ModDate).HasDefaultValue(DateTime.UtcNow);
        }
    }
}
