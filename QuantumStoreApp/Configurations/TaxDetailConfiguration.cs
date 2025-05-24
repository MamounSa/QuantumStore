using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using QuantumStore;

namespace QuantumStore
{
    public class TaxDetailConfiguration : IEntityTypeConfiguration<TaxDetail>
    {
        public void Configure(EntityTypeBuilder<TaxDetail> builder)
        {
            builder.HasKey(td => td.Id);
            builder.Property(td => td.TaxAmount).HasColumnType("decimal(18,2)");
            builder.HasOne(td => td.Order)
                   .WithMany()
                   .HasForeignKey(td => td.OrderId);
        }
    }

}
