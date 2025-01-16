using Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.EntityConfiguration
{
    public class SistemaCredencialMap : IEntityTypeConfiguration<SistemaCredencial>
    {
        public void Configure(EntityTypeBuilder<SistemaCredencial> builder)
        {
            builder.ToTable("sistema_credencial");

            builder.Property(e => e.SistemaId)
               .IsRequired()
               .HasColumnType("int")               
               .HasColumnName("sistema_id")
               .HasComment("Id do Sistema");

            builder.Property(e => e.Password)
               .HasColumnName("secret")
               .IsRequired()
               .HasMaxLength(64)
               .HasComment("Secret para autenticação na API em SHA256");         
           

            builder.Property(e => e.DataExpiracao)
                .HasColumnName("expire_at")
                .HasColumnType("timestamp")
                .HasComment("Data da ativação da secret");

            new EntityIntMap<SistemaCredencial>().AddCommonConfiguration(builder);

        }
    }
}
