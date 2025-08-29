using Microsoft.EntityFrameworkCore;
using Warehouse.Core.Inventory.Entities; // <--- ENTIDADES, não DTOs

namespace Warehouse.Infra.Data
{
    public class WarehouseDbContext : DbContext
    {
        public WarehouseDbContext(DbContextOptions<WarehouseDbContext> options)
            : base(options)
        {
        }

        public DbSet<Unit> Units { get; set; } = null!;
        public DbSet<Category> Categories { get; set; } = null!;
        public DbSet<Product> Products { get; set; } = null!;
        public DbSet<Movement> Movements { get; set; } = null!;
        public DbSet<Supplier> Suppliers { get; set; } = null!;
        public DbSet<ProductSupplier> ProductsSuppliers { get; set; } = null!;

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

            // Relationships
            modelBuilder.Entity<Product>()
                .HasOne<Unit>()
                .WithMany()
                .HasForeignKey(p => p.UnitId);

            modelBuilder.Entity<Product>()
                .HasOne<Category>()
                .WithMany()
                .HasForeignKey(p => p.CategoryId);

            modelBuilder.Entity<Movement>()
                .HasOne<Product>()
                .WithMany()
                .HasForeignKey(m => m.ProductId);

            modelBuilder.Entity<ProductSupplier>()
                .HasOne<Product>()
                .WithMany()
                .HasForeignKey(ps => ps.ProductId);

            modelBuilder.Entity<ProductSupplier>()
                .HasOne<Supplier>()
                .WithMany()
                .HasForeignKey(ps => ps.SupplierId);
        }
    }
}
