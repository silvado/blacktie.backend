using Domain.Entities.Abstracts;

namespace Domain.Models
{
    public class DocumentType : EntityInt
    {
        public string? Name { get; set; }
    }
}
