using Domain.Entities.Abstracts;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.EntityConfiguration
{
    public class EntityGuidMap<T> where T : EntityGuid
    {

        public void AddCommonConfiguration(EntityTypeBuilder<T> builder)
        {
            builder.HasKey(x => x.Id);

            builder.Property(c => c.Id)
                .HasColumnName("id");

            new EntityMap<T>().AddCommonConfiguration(builder);
        }
    }
}
