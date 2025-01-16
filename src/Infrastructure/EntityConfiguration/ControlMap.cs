using Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.EntityConfiguration
{
    public class ControlMap : IEntityTypeConfiguration<Control>
    {
        public void Configure(EntityTypeBuilder<Control> builder)
        {
            builder.ToTable("control");

            builder.Property(e => e.UserId)
                .IsRequired()
                .HasColumnName("user_id");

            builder.Property(e => e.ControlNumber)
               .IsRequired()
               .HasMaxLength(100)
               .HasColumnName("control_number");


            builder.Property(e => e.ExpireAt)
                .HasColumnType("timestamp")
                .HasColumnName("expire_at");
           

            new EntityGuidMap<Control>().AddCommonConfiguration(builder);

        }
    }
}
