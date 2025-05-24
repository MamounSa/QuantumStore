using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using QuantumStore;

namespace QuantumStore
{
    public class ShipmentConfiguration : IEntityTypeConfiguration<Shipment>
    {
        public void Configure(EntityTypeBuilder<Shipment> builder)
        {
            builder.HasKey(s => s.Id); // تعيين المفتاح الأساسي
            builder.Property(s => s.TrackingNumber)
                   .IsRequired()
                   .HasMaxLength(50); // رقم التتبع مطلوب وبطول محدد
            builder.Property(s => s.ShipmentDate)
                   .IsRequired(); // تاريخ الشحن مطلوب

            // العلاقة مع Order
            builder.HasOne(s => s.Order)
                   .WithOne(o => o.Shipment)
                   .HasForeignKey<Shipment>(s => s.OrderId);
        }
    }

}
