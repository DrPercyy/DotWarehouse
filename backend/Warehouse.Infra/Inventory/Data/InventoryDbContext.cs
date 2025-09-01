using Microsoft.EntityFrameworkCore;
using Warehouse.Core.Entities;
using Warehouse.Infra.Inventory.Data.Configurations;

namespace Warehouse.Infra.Inventory.Data
{
    // O DbContext é o ponto central de comunicação com o banco de dados
    public class InventoryDbContext : DbContext
    {
        public InventoryDbContext(DbContextOptions<InventoryDbContext> options)
            : base(options)
        { }

        // DbSets representam as tabelas no banco
        public DbSet<Unit> Units { get; set; } = null!;
        public DbSet<Category> Categories { get; set; } = null!;
        public DbSet<Product> Products { get; set; } = null!;
        public DbSet<Movement> Movements { get; set; } = null!;
        public DbSet<Supplier> Suppliers { get; set; } = null!;
        public DbSet<ProductSupplier> ProductSuppliers { get; set; } = null!;

        // Aplicação das configurações separadas por entidade
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.ApplyConfiguration(new UnitConfiguration());
            modelBuilder.ApplyConfiguration(new CategoryConfiguration());
            modelBuilder.ApplyConfiguration(new ProductConfiguration());
            modelBuilder.ApplyConfiguration(new MovementConfiguration());
            modelBuilder.ApplyConfiguration(new SupplierConfiguration());
            modelBuilder.ApplyConfiguration(new ProductSupplierConfiguration());
        }
    }
}
