using System.Runtime;

namespace Application.Contracts
{
    public class SistemaPublicacaoDto
    {
        public int Id { get; set; }
        public int SistemaId { get; set; }
        public string? Configuracao { get; set; }
        public DateTime? PublishedAt { get; set; }
        public string? PublishedByUserId { get; set; }
        public SistemaDto? Sistema { get; set; }

    }
}
