using Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.EntityConfiguration
{
    public class CountryMap : IEntityTypeConfiguration<Country>
    {
        public void Configure(EntityTypeBuilder<Country> builder)
        {
            builder.ToTable("country");

            builder.Property(e => e.Name)
                .IsRequired()
                .HasColumnName("name");

            builder.Property(e => e.CallingCode)
               .HasColumnName("calling_code");


            new EntityIntMap<Country>().AddCommonConfiguration(builder);

        }
    }
}
