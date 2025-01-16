using Domain.Entities.Abstracts;

namespace Domain.Models
{
    public class SistemaPublicacao : EntityInt
    {
        public int SistemaId { get; set; }
        public string? Configuracao { get; set; }                
        public DateTime? PublishedAt { get; set; }
        public string? PublishedByUserId { get; set; }
        public Sistema? Sistema { get; set; }

        
    }
}
