using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Warehouse.Core.Entities;

namespace Warehouse.Infra.Inventory.Data.Configurations
{
    // Configuração da entidade Supplier
    public class SupplierConfiguration : IEntityTypeConfiguration<Supplier>
    {
        public void Configure(EntityTypeBuilder<Supplier> builder)
        {
            builder.ToTable("suppliers");
            builder.HasKey(s => s.Id);

            builder.Property(s => s.LegalName)
                .IsRequired()
                .HasMaxLength(100);

            builder.Property(s => s.Email)
                .HasMaxLength(150);

            builder.Property(s => s.Phone)
                .HasMaxLength(20);
        }
    }
}