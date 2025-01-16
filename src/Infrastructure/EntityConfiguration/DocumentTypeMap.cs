using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using Domain.Models;

namespace Infrastructure.EntityConfiguration
{
    public class DocumentTypeMap : IEntityTypeConfiguration<DocumentType>
    {
        public void Configure(EntityTypeBuilder<DocumentType> builder)
        {
            builder.ToTable("document_type");

            builder.Property(e => e.Name)                
                .HasColumnName("name");                  


            new EntityIntMap<DocumentType>().AddCommonConfiguration(builder);

        }
    }
}
