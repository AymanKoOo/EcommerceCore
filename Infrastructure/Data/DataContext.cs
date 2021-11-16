using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using Core.Entites;
using Microsoft.AspNetCore.Identity;
using Infrastructure.ModelConfig;

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
        }

        public DbSet<Product> products { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderItem> orderItems { get; set; }
        public DbSet<CartItem> CartItems { get; set; }
        public DbSet<Cart> Carts { get; set; }

    }
}
