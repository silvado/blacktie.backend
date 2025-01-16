using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using Domain.Models;
using Domain.Enums;

namespace Infrastructure.EntityConfiguration
{
    public class OrderMap : IEntityTypeConfiguration<Order>
    {
        public void Configure(EntityTypeBuilder<Order> builder)
        {
            builder.ToTable("order");

            builder.Property(e => e.ProductId)
                .IsRequired()
                .HasColumnName("product_id");

            builder.Property(e => e.CustomerId)
                .IsRequired()
                .HasColumnName("customer_id");

            builder.Property(e => e.TotalPassengers)
                .IsRequired()
                .HasColumnName("total_passengers");

            builder.Property(e => e.TotalSmallBags)
                .IsRequired()
                .HasColumnName("total_smallbags");

            builder.Property(e => e.TotalBigBags)
                 .IsRequired()
                 .HasColumnName("total_bigbags");

            builder.Property(e => e.Amount)
                 .IsRequired()
                 .HasColumnName("amount");

            builder.Property(e => e.Price)
                 .IsRequired()
                 .HasColumnName("price");

            builder.Property(e => e.Date)
                 .IsRequired()
                 .HasColumnType("timestamp")
                 .HasColumnName("date");

            builder.Property(e => e.PaymentTypeId)
                .HasColumnName("payment_type_id");

            builder.Property(e => e.ExpireAt)
                .HasColumnType("timestamp")
                .HasColumnName("expire_at");

            builder.Property(e => e.PaymentStatus)
                .HasColumnName("payment_status")
                .IsRequired(false)
                .IsUnicode(false)
                .HasMaxLength(50)
                .HasConversion<string>(e => e.ToString()!, e => (EPaymentStatus)Enum.Parse(typeof(EPaymentStatus), e));


            new EntityGuidMap<Order>().AddCommonConfiguration(builder);

        }
    }
}
