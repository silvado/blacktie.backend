using Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.EntityConfiguration
{
    public class AuditMap : IEntityTypeConfiguration<Audit>
    {
        public void Configure(EntityTypeBuilder<Audit> builder)
        {
            builder.ToTable("audit");

            builder.HasKey(e => e.Id);

            builder.Property(p => p.Id).HasColumnName("id");

            builder.Property(p => p.UserId).HasColumnName("user_id");

            builder.Property(p => p.UserName).HasColumnName("user_name");

            builder.Property(p => p.Type).HasColumnName("type");

            builder.Property(p => p.TableName).HasColumnName("table_name");

            builder.Property(p => p.DateTime).HasColumnName("date_time").HasColumnType("timestamp");

            builder.Property(p => p.OldValues).HasColumnName("old_values").IsRequired(false);

            builder.Property(p => p.NewValues).HasColumnName("new_values").IsRequired(false);

            builder.Property(p => p.AffectedColumns).HasColumnName("affected_column").IsRequired(false);

            builder.Property(p => p.PrimaryKey).HasColumnName("primary_key");

        }
    }
}
