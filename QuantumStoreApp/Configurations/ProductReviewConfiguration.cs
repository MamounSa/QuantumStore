using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using QuantumStore;

namespace QuantumStore
{
    public class ProductReviewConfiguration : IEntityTypeConfiguration<ProductReview>
    {
        public void Configure(EntityTypeBuilder<ProductReview> builder)
        {
            builder.HasKey(pr => pr.Id);
            builder.Property(pr => pr.ReviewText).IsRequired().HasMaxLength(500);
            builder.Property(pr => pr.ReviewDate).HasColumnType("DATE").IsRequired();

            builder.HasOne(pr => pr.Product)
                   .WithMany(p => p.ProductReviews)
                   .HasForeignKey(pr => pr.ProductId);
            builder.HasOne(pr => pr.Customer)
                .WithMany(pr => pr.ProductReviews)
                .HasForeignKey(pr => pr.CustomerId);
        }
    }

}
