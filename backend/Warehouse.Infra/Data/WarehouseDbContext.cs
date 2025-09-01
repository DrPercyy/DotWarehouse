//file: backend/Warehouse.Infra/Data/WarehouseDbContext.cs

using Microsoft.EntityFrameworkCore;
using Warehouse.Core.Entities;

namespace Warehouse.Infra.Data
{
    public class WarehouseDbContext : DbContext
    {
        public WarehouseDbContext(DbContextOptions<WarehouseDbContext> options)
            : base(options)
        {
        }

        // DbSets
        public DbSet<Unit> Units { get; set; } = null!;
        public DbSet<Category> Categories { get; set; } = null!;
        public DbSet<Product> Products { get; set; } = null!;
        public DbSet<Movement> Movements { get; set; } = null!;
        public DbSet<Supplier> Suppliers { get; set; } = null!;
        public DbSet<ProductSupplier> ProductSuppliers { get; set; } = null!;

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Table naming
            modelBuilder.Entity<Unit>().ToTable("units");
            modelBuilder.Entity<Category>().ToTable("categories");
            modelBuilder.Entity<Product>().ToTable("products");
            modelBuilder.Entity<Movement>().ToTable("movements");
            modelBuilder.Entity<Supplier>().ToTable("suppliers");
            modelBuilder.Entity<ProductSupplier>().ToTable("products_suppliers");

            // Primary key for ProductSupplier
            modelBuilder.Entity<ProductSupplier>()
                .HasKey(ps => ps.Id);

            // Relationships
            modelBuilder.Entity<Product>()
                .HasOne(p => p.Unit)
                .WithMany()
                .HasForeignKey(p => p.UnitId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Product>()
                .HasOne(p => p.Category)
                .WithMany()
                .HasForeignKey(p => p.CategoryId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Movement>()
                .HasOne(m => m.Product)
                .WithMany(p => p.Movements)
                .HasForeignKey(m => m.ProductId)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<ProductSupplier>()
                .HasOne(ps => ps.Product)
                .WithMany(p => p.ProductSuppliers)
                .HasForeignKey(ps => ps.ProductId)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<ProductSupplier>()
                .HasOne(ps => ps.Supplier)
                .WithMany(s => s.ProductSuppliers)
                .HasForeignKey(ps => ps.SupplierId)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
