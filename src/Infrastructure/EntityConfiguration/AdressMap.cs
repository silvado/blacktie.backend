using Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.EntityConfiguration
{
    public class AddressMap : IEntityTypeConfiguration<Address>
    {
        public void Configure(EntityTypeBuilder<Address> builder)
        {
            builder.ToTable("address");

            builder.Property(e => e.Street)
               .IsRequired()
               .HasMaxLength(100)
               .HasColumnName("street");

            builder.Property(e => e.Number)
                .HasColumnName("number")
                .HasMaxLength(10);

            builder.Property(e => e.Complement)
                .HasColumnName("complement")
                .HasMaxLength(100);

            builder.Property(e => e.Locality)
                .HasColumnName("locality")
                .HasMaxLength(50);

            builder.Property(e => e.City)
               .HasColumnName("city")
               .HasMaxLength(50);

             builder.Property(e => e.RegionCode)
               .HasColumnName("region_code")
               .HasMaxLength(5);

            builder.Property(e => e.CountryId)
               .HasColumnName("country_id")
               .HasMaxLength(50);

             builder.Property(e => e.PostalCode)
               .HasColumnName("postal_code")
               .HasMaxLength(50);
                        
            new EntityIntMap<Address>().AddCommonConfiguration(builder);

        }
    }
}
