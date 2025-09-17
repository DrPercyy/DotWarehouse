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

            // Primary keys
            modelBuilder.Entity<Unit>().HasKey(u => u.Id);
            modelBuilder.Entity<Category>().HasKey(c => c.Id);
            modelBuilder.Entity<Product>().HasKey(p => p.Id);
            modelBuilder.Entity<Movement>().HasKey(m => m.Id);
            modelBuilder.Entity<Supplier>().HasKey(s => s.Id);
            modelBuilder.Entity<ProductSupplier>().HasKey(ps => ps.Id);

            // Relationships
            modelBuilder.Entity<Product>()
                .HasOne(p => p.Unit)
                .WithMany(u => u.Products) // Alinhado com Unit.cs
                .HasForeignKey(p => p.UnitId)
                .HasConstraintName("FK_Product_Unit")
                .OnDelete(DeleteBehavior.Restrict)
                .IsRequired(); // UnitId é obrigatório

            modelBuilder.Entity<Product>()
                .HasOne(p => p.Category)
                .WithMany(c => c.Products) // Alinhado com Category.cs
                .HasForeignKey(p => p.CategoryId)
                .HasConstraintName("FK_Product_Category")
                .OnDelete(DeleteBehavior.Restrict)
                .IsRequired(); // CategoryId é obrigatório

            modelBuilder.Entity<Movement>()
                .HasOne(m => m.Product)
                .WithMany(p => p.Movements)
                .HasForeignKey(m => m.ProductId)
                .HasConstraintName("FK_Movement_Product")
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<ProductSupplier>()
                .HasOne(ps => ps.Product)
                .WithMany(p => p.ProductSuppliers)
                .HasForeignKey(ps => ps.ProductId)
                .HasConstraintName("FK_ProductSupplier_Product")
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<ProductSupplier>()
                .HasOne(ps => ps.Supplier)
                .WithMany(s => s.ProductSuppliers)
                .HasForeignKey(ps => ps.SupplierId)
                .HasConstraintName("FK_ProductSupplier_Supplier")
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}