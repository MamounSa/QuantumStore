using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using QuantumStore;

namespace QuantumStore
{
    public class OrderDetailConfiguration : IEntityTypeConfiguration<OrderDetail>
    {
        public void Configure(EntityTypeBuilder<OrderDetail> builder)
        {
            builder.HasKey(od => od.Id);
            builder.Property(od => od.Quantity).IsRequired();
            builder.Property(od => od.TotalPrice).HasColumnType("decimal(18,2)");
            builder.HasOne(od => od.Order)
                   .WithMany(o => o.OrderDetails)
                   .HasForeignKey(od => od.OrderId);
            builder.HasOne(od => od.Product)
                   .WithMany()
                   .HasForeignKey(od => od.ProductId);
        }
    }

}
