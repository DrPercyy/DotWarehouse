using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Warehouse.Core.Entities;

namespace Warehouse.Infra.Inventory.Data.Configurations
{
    // Configuração da entidade Product
    public class ProductConfiguration : IEntityTypeConfiguration<Product>
    {
        public void Configure(EntityTypeBuilder<Product> builder)
        {
            builder.ToTable("products");       // Nome da tabela
            builder.HasKey(p => p.Id);         // PK

            // Propriedades com validações
            builder.Property(p => p.Name)
                   .IsRequired()
                   .HasMaxLength(100);

            builder.Property(p => p.Description)
                   .HasMaxLength(500);

            builder.Property(p => p.Price)
                   .HasColumnType("decimal(18,2)")
                   .IsRequired();

            builder.Property(p => p.Barcode)
                   .HasMaxLength(50);

            builder.Property(p => p.ImageUrl)
                   .HasMaxLength(250);

            builder.Property(p => p.Active)
                   .IsRequired();

            // Relacionamentos
            builder.HasOne(p => p.Unit)
                   .WithMany()
                   .HasForeignKey(p => p.UnitId)
                   .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(p => p.Category)
                   .WithMany()
                   .HasForeignKey(p => p.CategoryId)
                   .OnDelete(DeleteBehavior.Restrict);

            builder.HasMany(p => p.Movements)
                   .WithOne(m => m.Product)
                   .HasForeignKey(m => m.ProductId)
                   .OnDelete(DeleteBehavior.Cascade);

            builder.HasMany(p => p.ProductSuppliers)
                   .WithOne(ps => ps.Product)
                   .HasForeignKey(ps => ps.ProductId)
                   .OnDelete(DeleteBehavior.Cascade);

            // Índice único para código de barras
            builder.HasIndex(p => p.Barcode).IsUnique();
        }
    }
}
