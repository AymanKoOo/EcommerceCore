using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using Core.Entites;
using Microsoft.AspNetCore.Identity;
using Infrastructure.ModelConfig;
using Core.Entites.Base;
using Core.Entites.Discounts;
using Core.Entites.Catalog;
using Core.Entites.Orders;
using Core.Entites.Common;
using Core.Entites.Shipping;
using Core.Entites.Payments;

namespace Infrastructure.Data
{
    public class DataContext: IdentityDbContext<ApplicationUser, ApplicationRole, string>
    {

        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {
        }
        protected override void OnModelCreating(ModelBuilder builder)
        {

            new ProductTypeConfig().Configure(builder.Entity<Product>());
            base.OnModelCreating(builder);

          

            builder.Entity<DiscountProduct>().HasKey(sc => new { sc.ProductsId, sc.DiscountsId });

            builder.Entity<CategoryPicture>().HasKey(sc => new { sc.categoryID, sc.PictureId });

            builder.Entity<CategoryPicture>()
              .HasOne(pt => pt.category)
              .WithMany(p => p.categoryPictures)
              .HasForeignKey(pt => pt.categoryID);

            builder.Entity<CategoryPicture>()
                .HasOne(pt => pt.picture)
                .WithMany(t => t.categoryPictures)
                .HasForeignKey(pt => pt.PictureId);


            builder.Entity<ProductPicture>().HasKey(sc => new { sc.ProductId, sc.PictureId });

            builder.Entity<ProductPicture>()
               .HasOne(pt => pt.product)
               .WithMany(p => p.productPictures)
               .HasForeignKey(pt => pt.ProductId);

            builder.Entity<ProductPicture>()
                .HasOne(pt => pt.picture)
                .WithMany(t => t.productPictures)
                .HasForeignKey(pt => pt.PictureId);


            builder.Entity<ProductSpecificationAttribute>().HasKey(sc => new { sc.ProductId, sc.SpecificationAttributeOptionId });

            builder.Entity<ProductSpecificationAttribute>()
               .HasOne(pt => pt.product)
               .WithMany(p => p.ProductSpecificationAttributes)
               .HasForeignKey(pt => pt.ProductId);

            builder.Entity<ProductSpecificationAttribute>()
                .HasOne(pt => pt.specificationAttributeOption)
                .WithMany(t => t.ProductSpecificationAttributes)
                .HasForeignKey(pt => pt.SpecificationAttributeOptionId);


            builder.Entity<CategorySpecificationGroup>().HasKey(sc => new { sc.CategoryId, sc.SpecificationAttributeGroupId });

            builder.Entity<CategorySpecificationGroup>()
               .HasOne(pt => pt.category)
               .WithMany(p => p.CategorySpecificationGroups)
               .HasForeignKey(pt => pt.CategoryId);

            builder.Entity<CategorySpecificationGroup>()
                .HasOne(pt => pt.specificationAttributeGroup)
                .WithMany(t => t.CategorySpecificationGroups)
                .HasForeignKey(pt => pt.SpecificationAttributeGroupId);




            //builder.Entity<ProductAttributeMapping>().HasKey(sc => new { sc.ProductId, sc.ProductAttributeId });

            //builder.Entity<ProductAttributeMapping>()
            //    .HasOne(x => x.product)
            //    .WithMany(x => x.ProductAttributeMappings)
            //    .HasForeignKey(x => x.ProductId);

          
            //builder.Entity<ProductAttributeMapping>()
            //    .HasOne(x => x.productAttribute)
            //    .WithMany(x => x.ProductAttributeMappings)
            //    .HasForeignKey(x => x.ProductAttributeId);

        }

        public DbSet<Product> products { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderItem> orderItems { get; set; }
        public DbSet<OrderNotes> orderNotes { get; set; }
        public DbSet<Address> Address { get; set; }
        public DbSet<CartItem> CartItems { get; set; }
        public DbSet<Cart> Carts { get; set; }
        public DbSet<Discount> discounts { get; set; }
        public DbSet<DiscountProduct> discountProducts { get; set; }
        public DbSet<ProductPicture> productPictures { get; set; }
        public DbSet<CategoryPicture> categoryPictures { get; set; }
        public DbSet<Picture> pictures { get; set; }
        public DbSet<Shipment> shipments { get; set; }
        public DbSet<ShipmentItem> shipmentItems { get; set; }
        public DbSet<ShippingMethods> shippingMethods { get; set; }

        public DbSet<PaymentMethods> paymentMethods { get; set; }
        
        public DbSet<SpecificationAttribute> specificationAttributes { get; set; }
        public DbSet<SpecificationAttributeGroup> specificationAttributeGroups { get; set; }
        public DbSet<SpecificationAttributeOption> SpecificationAttributeOptions { get; set; }
        public DbSet<ProductSpecificationAttribute> ProductSpecificationAttribute { get; set; }
        public DbSet<CategorySpecificationGroup> categorySpecificationGroups { get; set; }



        public DbSet<ProductAttribute> productAttributes { get; set; }
        public DbSet<ProductAttributeOption> productAttributeOptions { get; set; }
        public DbSet<ProductAttributeMapping> productAttributeMappings { get; set; }
    }
}
