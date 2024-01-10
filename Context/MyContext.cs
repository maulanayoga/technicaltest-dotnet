using Microsoft.EntityFrameworkCore;
using TestBackend.Models;

namespace TestBackend.Context
{
    public class MyContext : DbContext
    {
        public MyContext(DbContextOptions<MyContext> options) : base(options)
        {


        }
        public DbSet<Product> Products { get; set; }
        public DbSet<Sale> Sales { get; set; }
        //public DbSet<ProductSale> ProductSales { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Sale>()
            .HasOne(p => p.Product)
            .WithMany()
            .HasForeignKey(p => p.ProductId);

            base.OnModelCreating(modelBuilder);

        }
    }
}
