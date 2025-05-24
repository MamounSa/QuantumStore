using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using QuantumStore;

namespace QuantumStore
{
    public class OrderConfiguration : IEntityTypeConfiguration<Order>
    {
        public void Configure(EntityTypeBuilder<Order> builder)
        {
            builder.HasKey(o => o.Id);
            builder.Property(o => o.OrderDate).IsRequired();

            //builder.HasOne(o => o.Customer)
            //       .WithMany(c => c.Orders)
            //       .HasForeignKey(o => o.CustomerId)
            //       .OnDelete(DeleteBehavior.Restrict)
            //       ;

            builder.HasMany(o => o.Returns)
       .WithOne(r => r.Order)
       .HasForeignKey(r => r.OrderId)
       .OnDelete(DeleteBehavior.Restrict); // منع الحذف التلقائي

        }
    }

}
