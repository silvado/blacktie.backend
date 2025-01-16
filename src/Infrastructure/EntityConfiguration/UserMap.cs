using Domain.Models;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.EntityConfiguration
{
    public class UserMap : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.ToTable("user");

            builder.Property(e => e.Name)
               .IsRequired()
               .HasMaxLength(100)
               .HasColumnName("name");            

            builder.Property(e => e.Password)
                .HasColumnName("password")
                .HasMaxLength(100);

            builder.Property(e => e.Email)
                .IsRequired()
                .HasColumnName("email")
                .HasMaxLength(50);

            builder.Property(e => e.IsAdmin)
                .IsRequired()
                .HasColumnName("is_admin");

            builder.Ignore(e => e.Token);

            new EntityGuidMap<User>().AddCommonConfiguration(builder);

        }
    }
}
