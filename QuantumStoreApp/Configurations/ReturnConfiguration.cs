using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using QuantumStore;

namespace QuantumStore
{
    public class ReturnConfiguration : IEntityTypeConfiguration<Return>
    {
        public void Configure(EntityTypeBuilder<Return> builder)
        {
            // تعريف المفتاح الأساسي
            builder.HasKey(r => r.Id);

            // قيود الحقول
            builder.Property(r => r.Reason)
                   .IsRequired()
                   .HasMaxLength(250); // طول النص للسبب

            builder.Property(r => r.ReturnDate)
                   .IsRequired(); // تاريخ الإرجاع مطلوب

            builder.Property(r => r.Status)
                   .IsRequired()
                   .HasMaxLength(50); // حالة الإرجاع

            //// العلاقة مع Order
            //builder.HasOne(r => r.Order)
            //       .WithMany(o => o.Returns)
            //       .HasForeignKey(r => r.OrderId)
            //       .OnDelete(DeleteBehavior.Restrict); // منع الحذف التلقائي

            //// العلاقة مع Customer
            //builder.HasOne(r => r.Customer)
            //       .WithMany(c => c.Returns)
            //       .HasForeignKey(r => r.CustomerId)
            //       .OnDelete(DeleteBehavior.Restrict); // تعيين المفتاح الأجنبي إلى NULL
        }
    }

}
