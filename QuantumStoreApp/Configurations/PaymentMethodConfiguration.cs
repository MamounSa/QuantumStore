using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using QuantumStore;

namespace QuantumStore
{
    public class PaymentMethodConfiguration : IEntityTypeConfiguration<PaymentMethod>
    {
        public void Configure(EntityTypeBuilder<PaymentMethod> builder)
        {
            builder.HasKey(pm => pm.Id); // تعيين المفتاح الأساسي
            builder.Property(pm => pm.Name)
                   .IsRequired()
                   .HasMaxLength(50); // اسم طريقة الدفع مطلوب
            builder.Property(pm => pm.Fee)
                   .HasColumnType("decimal(18,2)"); // تحديد نوع الحقل
            builder.Property(pm => pm.IsActive)
                   .IsRequired(); // الحالة مطلوبة

            // العلاقة مع Payment
            builder.HasMany(pm => pm.Payments)
                   .WithOne(p => p.PaymentMethod)
                   .HasForeignKey(p => p.PaymentMethodId);
        }
    }

}
