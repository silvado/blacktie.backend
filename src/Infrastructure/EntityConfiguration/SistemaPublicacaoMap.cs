using Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.EntityConfiguration
{
    public class SistemaPublicacaoMap : IEntityTypeConfiguration<SistemaPublicacao>
    {
        public void Configure(EntityTypeBuilder<SistemaPublicacao> builder)
        {
            builder.ToTable("sistema_publicacao");

            builder.Property(e => e.SistemaId)
               .IsRequired()
               .HasColumnType("int")
               .HasColumnName("sistema_id")
               .HasComment("Id do Sistema");

            builder.Property(e => e.Configuracao)
               .HasColumnName("configuracao")
                .HasColumnType("jsonb")
                .IsUnicode(false)
                .HasComment("JSON das configurações da aplicação publicada");

            builder.Property(e => e.PublishedAt)
                .HasColumnName("published_at")
                .HasColumnType("timestamp")
                .HasComment("Data da publicação");

            builder.Property(e => e.PublishedByUserId)
                .HasColumnName("published_by_user")
                .HasColumnType("VARCHAR(40)")
                .HasComment("Usuario que fez a publicação");

            new EntityIntMap<SistemaPublicacao>().AddCommonConfiguration(builder);

        }
    }
}
