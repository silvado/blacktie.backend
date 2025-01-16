using Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.EntityConfiguration
{
    public class CustomerMap : IEntityTypeConfiguration<Customer>
    {
        public void Configure(EntityTypeBuilder<Customer> builder)
        {
            builder.ToTable("customer");

            builder.Property(e => e.TaxId)
               .IsRequired()
               .HasMaxLength(11)
               .HasColumnName("tax_id");

            builder.Property(e => e.DocumentTypeId)
             .IsRequired()
             .HasColumnName("document_type_id");

            builder.Property(e => e.CountryId)
              .IsRequired()             
              .HasColumnName("country_id");

            builder.Property(e => e.Name)
                .HasColumnName("name")                
                .HasMaxLength(100);

            builder.Property(e => e.Email)
                .HasColumnName("email")                
                .HasMaxLength(50);

             builder.Property(e => e.Phone)
                .HasColumnName("phone")                
               .HasMaxLength(50);

            builder.Ignore(e => e.TempControle);           
            builder.Ignore(e => e.UserId);           


            new EntityGuidMap<Customer>().AddCommonConfiguration(builder);

        }
    }
}
