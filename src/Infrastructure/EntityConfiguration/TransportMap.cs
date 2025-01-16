using Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.EntityConfiguration
{
    public class TransportMap : IEntityTypeConfiguration<Transport>
    {
        public void Configure(EntityTypeBuilder<Transport> builder)
        {
            builder.ToTable("transport");

            builder.Property(e => e.Brand)
               .IsRequired()
               .HasMaxLength(11)
               .HasColumnName("brand");

            builder.Property(e => e.Name)
                .HasColumnName("name")
                .HasMaxLength(100);

            builder.Property(e => e.Model)
                .HasColumnName("model")
                .HasMaxLength(50);

            builder.Property(e => e.Image)
               .HasColumnName("image")
               .HasColumnType("TEXT");

            builder.Property(e => e.YoutubeLink)
               .HasColumnName("youtube_link");

            new EntityGuidMap<Transport>().AddCommonConfiguration(builder);

        }
    }
}
