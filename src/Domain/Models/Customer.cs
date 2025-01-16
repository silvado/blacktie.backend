using Domain.Entities.Abstracts;
using System.Diagnostics.CodeAnalysis;

namespace Domain.Models
{
    [ExcludeFromCodeCoverage]
    public class Customer : EntityGuid
    {           
        public string? Name { get; set; }        
        public string? TaxId { get; set; }        
        public int CountryId { get; set; }
        public int DocumentTypeId { get; set; }
        public string? Email { get; set; }        
        public string? Phone { get; set; }
        public virtual Guid? UserId { get; set; }
        public virtual int? TempControle { get; set; }
        public virtual Country Country { get; set; }
        public virtual DocumentType DocumentType { get; set; }
        public virtual ICollection<CustomerAddress> CustomerAddresses { get; set; }        
    }
}
