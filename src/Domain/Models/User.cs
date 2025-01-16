using Domain.Entities.Abstracts;

namespace Domain.Models
{
    public class User: EntityGuid
    {
        public string? Name { get; set; }        
        public string? Email { get; set; }
        public string? Password { get; set; }
        public virtual string? Token { get; set; }
    }
}
