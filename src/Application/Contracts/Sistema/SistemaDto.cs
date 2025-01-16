using System.Runtime;

namespace Application.Contracts
{
    public class SistemaDto
    {
        public int Id { get; set; }
        public string? NomeSistema { get; set; }
        public string? SiglaSistema { get; set; }
        public object? Configuracao { get; set; }
        public object? ConfiguracaoPrevia { get; set; }
        public string? Username { get; set; }        
        public DateTime? PublishedAt { get; set; }
        public string? PublishedByUserId { get; set; }
        public DateTime? CreatedAt { get; set; }
        public string? CreatedByUserId { get; set; }
        public DateTime? UpdateAt { get; set; }
        public string? UpdatedByUserId { get; set; }
        public double? PasswordExpirationInHours { get; set; }

    }
}
