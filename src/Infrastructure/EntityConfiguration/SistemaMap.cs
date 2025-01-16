using Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.EntityConfiguration
{
    public class SistemaMap : IEntityTypeConfiguration<Sistema>
    {
        public void Configure(EntityTypeBuilder<Sistema> builder)
        {
            builder.ToTable("sistema");          

            builder.Property(e => e.NomeSistema)
               .IsRequired()
               .HasMaxLength(200)
               .HasColumnName("nome_sistema")
               .HasComment("Nome da Aplicação");

            builder.Property(e => e.SiglaSistema)
                .HasColumnName("sigla_sistema")
                .IsUnicode(false)
                .HasMaxLength(10)
                .HasComment("Sigla da Aplicação");

            builder.Property(e => e.Username)
                .HasColumnName("username")
                .IsRequired()
                .HasMaxLength(25)
                .HasComment("User para autenticação na API");

            builder.Property(e => e.Password)
                .HasColumnName("secret")
                .IsRequired()
                .HasMaxLength(64)
                .HasComment("Secret para autenticação na API em SHA256");

            builder.Property(e => e.Configuracao)
                .HasColumnName("configuracao")
                .HasColumnType("jsonb")
                .IsUnicode(false)
                .HasComment("JSON das configurações da aplicação, já publicada");

            builder.Property(e => e.ConfiguracaoPrevia)
                .HasColumnName("configuracao_previa")
                .HasColumnType("jsonb")
                .IsUnicode(false)
                .HasComment("JSON das configurações prévias, antes da publicação");

            builder.Property(e => e.PublishedAt)
                .HasColumnName("published_at")
                .HasColumnType("timestamp")
                .HasComment("Data da última publicação");

            builder.Property(e => e.PublishedByUserId)
                .HasColumnName("published_by_user")
                .HasColumnType("VARCHAR(40)")
                .HasComment("Usuario que fez a última publicação");


            new EntityIntMap<Sistema>().AddCommonConfiguration(builder);

        }
    }
}
