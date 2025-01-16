using Domain.Entities.Abstracts;

namespace Domain.Models
{
    public class SistemaCredencial: EntityInt
    {        
        public int SistemaId { get; set; }
        public string? Password { get; set; }        
        public DateTime? DataExpiracao { get; set; }
        
        public Sistema? Sistema { get; set; }

       
    }
}
