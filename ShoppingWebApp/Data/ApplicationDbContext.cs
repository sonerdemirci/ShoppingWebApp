using Microsoft.EntityFrameworkCore;
using ShoppingWebApp.Models;
using System.Collections.Generic;

namespace ShoppingWebApp.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options) { }

        public DbSet<ProductModel> Products { get; set; }
        public DbSet<Category> Categories { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ProductModel>()
               .HasKey(p => p.ProductID);

            modelBuilder.Entity<ProductModel>()
                .HasOne(p => p.Category)
                .WithMany(c => c.Products)
                .HasForeignKey(p => p.CategoryID);

            modelBuilder.Entity<Category>()
                .HasKey(c => c.CategoryID); 
        }
    }
}

// paketi indirirken hata alırsa Tools -> NuGet Package Manager -> Package Manager Console açıp aşağıdaki komutu çalıştırılır
// Install-Package Microsoft.EntityFrameworkCore.SqlServer
