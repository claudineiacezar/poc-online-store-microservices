using InventoryService.Models;
using Microsoft.EntityFrameworkCore;

namespace InventoryService.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> opt) : base(opt)
        {
            
        }
        public DbSet<Product> Products { get; set; }
        public DbSet<Inventory> Inventory { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder
                .Entity<Product>()
                .HasMany(p => p.Invetory)
                .WithOne(p => p.Product!)
                .HasForeignKey(p => p.ProductId);
            modelBuilder
                .Entity<Inventory>()
                .HasOne(p => p.Product)
                .WithMany(p => p.Invetory)
                .HasForeignKey(p => p.ProductId);

        }
    }
}