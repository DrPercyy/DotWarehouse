using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Warehouse.Core.Entities;

namespace Warehouse.Infra.Inventory.Data.Configurations
{
    // Configuração da entidade Movement
    public class MovementConfiguration : IEntityTypeConfiguration<Movement>
    {
        public void Configure(EntityTypeBuilder<Movement> builder)
        {
            builder.ToTable("movements");
            builder.HasKey(m => m.Id);

            builder.Property(m => m.Quantity)
                .IsRequired();

            builder.Property(m => m.CreateDate)
                .IsRequired();

            // Relacionamento com Product
            builder.HasOne(m => m.Product)
                .WithMany(p => p.Movements)
                .HasForeignKey(m => m.ProductId)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}