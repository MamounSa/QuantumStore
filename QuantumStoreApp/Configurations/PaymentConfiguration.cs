using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using QuantumStore;
namespace QuantumStore
{
    public class PaymentConfiguration : IEntityTypeConfiguration<Payment>
    {
        public void Configure(EntityTypeBuilder<Payment> builder)
        {
            builder.HasKey(p => p.Id);
            builder.Property(p => p.Amount).IsRequired();
            builder.Property(p => p.PaymentDate).IsRequired();

            // العلاقة مع PaymentMethod
            builder.HasOne(p => p.PaymentMethod)
                   .WithMany(pm => pm.Payments)
                   .HasForeignKey(p => p.PaymentMethodId);
        }
    }
}
