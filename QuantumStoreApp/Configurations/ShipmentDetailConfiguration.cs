using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using QuantumStore;

namespace QuantumStore
{
    public class ShipmentDetailConfiguration : IEntityTypeConfiguration<ShipmentDetail>
    {
        public void Configure(EntityTypeBuilder<ShipmentDetail> builder)
        {
            builder.HasKey(sd => sd.Id);
            builder.Property(sd => sd.Address).IsRequired().HasMaxLength(200);
            builder.HasOne(sd => sd.Shipment)
                   .WithMany()
                   .HasForeignKey(sd => sd.ShipmentId);
        }
    }

}
