using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using QuantumStore;

namespace QuantumStore
{
    public class DiscountConfiguration : IEntityTypeConfiguration<Discount>
    {
        public void Configure(EntityTypeBuilder<Discount> builder)
        {
            builder.HasKey(d => d.Id); // تعيين المفتاح الأساسي
            builder.Property(d => d.Name)
                   .IsRequired()
                   .HasMaxLength(100); // اسم العرض مطلوب
            builder.Property(d => d.DiscountAmount)
                   .HasColumnType("decimal(18,2)"); // تحديد نوع القيمة

            // العلاقة مع المنتجات
            builder.HasMany(d => d.Products)
                   .WithOne(d=>d.Discount)
                   .HasForeignKey(p => p.DiscountId); // إضافة مفتاح أجنبي في المنتج للإشارة إلى الخصم
        }
    }

}
