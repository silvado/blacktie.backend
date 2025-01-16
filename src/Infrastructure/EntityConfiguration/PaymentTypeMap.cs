using Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.EntityConfiguration
{
    public class PaymentTypeMap : IEntityTypeConfiguration<PaymentType>
    {
        public void Configure(EntityTypeBuilder<PaymentType> builder)
        {
            builder.ToTable("payment_type");

            builder.Property(e => e.Name)
                .HasColumnName("name");

            builder.Property(e => e.CodeName)
                .HasColumnName("code_name");

            new EntityIntMap<PaymentType>().AddCommonConfiguration(builder);

        }
    }
}
