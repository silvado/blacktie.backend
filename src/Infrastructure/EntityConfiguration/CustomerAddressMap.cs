using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using Domain.Models;

namespace Infrastructure.EntityConfiguration
{
    public class CustomerAddressMap : IEntityTypeConfiguration<CustomerAddress>
    {
        public void Configure(EntityTypeBuilder<CustomerAddress> builder)
        {
            builder.ToTable("customer_address");

            builder.HasKey(ot => new { ot.CustomerId, ot.AddressId });

            builder.Property(ot => ot.CustomerId).HasColumnName("customer_id");
            builder.Property(ot => ot.AddressId).HasColumnName("address_id");

            builder.HasOne(ot => ot.Address)
                .WithMany(o => o.CustomerAddresses)
                .HasForeignKey(ot => ot.CustomerId)
                .OnDelete(DeleteBehavior.Cascade);

            builder.HasOne(ot => ot.Address)
                .WithMany(o => o.CustomerAddresses)
                .HasForeignKey(ot => ot.AddressId)
                .OnDelete(DeleteBehavior.Cascade);

        }
    }
}
