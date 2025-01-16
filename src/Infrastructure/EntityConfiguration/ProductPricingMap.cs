using Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.EntityConfiguration
{
    public class ProductPricingMap : IEntityTypeConfiguration<ProductPricing>
    {
        public void Configure(EntityTypeBuilder<ProductPricing> builder)
        {
            builder.ToTable("product_pricing");

            builder.Property(e => e.ProductId)
                .HasColumnName("product_id");            

            builder.Property(e => e.DiscountPercent)
                .HasColumnName("discount_percent");

            builder.Property(e => e.PaymentTypeId)
               .HasColumnName("payment_type_id");

            builder.Property(e => e.Available)
               .HasColumnName("available");

            builder.HasOne(tv => tv.Product)
               .WithMany(t => t.Pricing)
               .HasForeignKey(tv => tv.ProductId)
               .OnDelete(DeleteBehavior.Cascade);

            new EntityIntMap<ProductPricing>().AddCommonConfiguration(builder);

        }
    }
}
