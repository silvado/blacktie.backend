using Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.EntityConfiguration
{
    public class TransportVariationMap : IEntityTypeConfiguration<TransportVariation>
    {
        public void Configure(EntityTypeBuilder<TransportVariation> builder)
        {
            builder.ToTable("transport_variation");

            builder.Property(e => e.TotalSmallBags)
               .IsRequired()               
               .HasColumnType("int")
               .HasColumnName("small_bags");

            builder.Property(e => e.TotalBigBags)
               .IsRequired()               
               .HasColumnType("int")
               .HasColumnName("big_bags");

            builder.Property(e => e.TotalPassengers)
                .IsRequired()
                .HasColumnName("passengers")
                .HasColumnType("int");

            builder.Property(e => e.TransportId)
                .IsRequired()
                .HasColumnName("transport_id");

            builder.HasOne(tv => tv.Transport)
               .WithMany(t => t.Variations)
               .HasForeignKey(tv => tv.TransportId)
               .OnDelete(DeleteBehavior.Cascade);

            new EntityIntMap<TransportVariation>().AddCommonConfiguration(builder);

        }
    }
}
