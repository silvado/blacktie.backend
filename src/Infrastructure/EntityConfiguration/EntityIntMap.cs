using Domain.Entities.Abstracts;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.EntityConfiguration
{
    public class EntityIntMap<T> where T : EntityInt
    {

        public void AddCommonConfiguration(EntityTypeBuilder<T> builder)
        {
            builder.HasKey(x => x.Id);

            builder.Property(c => c.Id)
                .HasColumnName("id")
                .HasColumnType("int");

            new EntityMap<T>().AddCommonConfiguration(builder);

        }

    }
}
