using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using Domain.Models;

namespace Infrastructure.EntityConfiguration
{
    public class FromToMap : IEntityTypeConfiguration<FromTo>
    {
        public void Configure(EntityTypeBuilder<FromTo> builder)
        {
            builder.ToTable("from_to");

            builder.Property(e => e.Name)
                .HasColumnName("name");

            new EntityIntMap<FromTo>().AddCommonConfiguration(builder);

        }
    }
}
