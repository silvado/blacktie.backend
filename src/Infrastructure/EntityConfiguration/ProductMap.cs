using Domain.Models;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.EntityConfiguration
{
    public class ProductMap : IEntityTypeConfiguration<Product>
    {
        public void Configure(EntityTypeBuilder<Product> builder)
        {
            builder.ToTable("product");

            builder.Property(e => e.FromId)
                .IsRequired()
                .HasColumnName("from_id");

            builder.Property(e => e.ToId)
                .IsRequired()
                .HasColumnName("to_id");

            builder.Property(e => e.TransportId)
                .IsRequired()
                .HasColumnName("transport_id");

            builder.Property(e => e.Price)
                .IsRequired()
                .HasColumnName("price");  
            
           builder.Property(e => e.IsLocked)
                .IsRequired()
                .HasColumnName("is_locked");    
            
           builder.Property(e => e.Comments)                
                .HasColumnName("comments");           
           

            new EntityGuidMap<Product>().AddCommonConfiguration(builder);

        }
    }
}
