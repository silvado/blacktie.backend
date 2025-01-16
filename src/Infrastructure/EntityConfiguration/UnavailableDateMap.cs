using Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.EntityConfiguration
{
    public class UnavailableDateMap : IEntityTypeConfiguration<UnavailableDate>
    {
        public void Configure(EntityTypeBuilder<UnavailableDate> builder)
        {
            builder.ToTable("unavailable_date");


            builder.Property(e => e.Year)
               .IsRequired()
               .HasColumnName("year");

            builder.Property(e => e.StartAt)
                .IsRequired()
                .HasColumnName("start_at");

            builder.Property(e => e.EndAt)
               .HasColumnName("end_at");
            
            builder.Property(e => e.Obs)
               .HasMaxLength(100)
               .HasColumnName("obs");

            new EntityIntMap<UnavailableDate>().AddCommonConfiguration(builder);

        }
    }
}
