using Domain.Entities.Abstracts;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.Models
{
    public class Sistema: EntityInt
    {
        public string? SiglaSistema { get; set; }
        public string? NomeSistema { get; set; }
        public string? Configuracao { get; set; }
        public string? ConfiguracaoPrevia { get; set; }
        public string? Username { get; set; } 
        public string? Password { get; set; }
        [NotMapped]
        public double? PasswordExpirationInHours { get; set; }
        public DateTime? PublishedAt { get; set; }
        public string? PublishedByUserId { get; set; }

       
    }
}
