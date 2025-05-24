using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;


namespace QuantumStore
{
    public class CartConfiguration : IEntityTypeConfiguration<Cart>
    {
        public void Configure(EntityTypeBuilder<Cart> builder)
        {
            builder.HasKey(c => c.Id);
            builder.HasOne(c => c.Customer)
                   .WithOne()
                   .HasForeignKey<Cart>(c => c.CustomerId);
        }
    }

}
