using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using QuantumStore;

namespace QuantumStore
{
    public class InventoryConfiguration : IEntityTypeConfiguration<Inventory>
    {
        public void Configure(EntityTypeBuilder<Inventory> builder)
        {
            // Define the primary key
            builder.HasKey(i => i.Id);

            // Define Quantity as required
            builder.Property(i => i.Quantity)
                   .IsRequired();

            // Relationship with Product
            builder.HasOne(i => i.Product)
                   .WithMany(p => p.InventoryRecords)
                   .HasForeignKey(i => i.ProductId);

            // Relationship with Warehouse
            builder.HasOne(i => i.Warehouse)
                   .WithMany(w => w.InventoryItems)
                   .HasForeignKey(i => i.WarehouseId);
        }
    }

}
