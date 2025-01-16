using Domain.Entities.Abstracts;

namespace Domain.Models
{
    public class Address: EntityInt
    {        
        public string? Street { get; set; }
        public string? Number { get; set; }
        public string? Complement { get; set; }
        public string? Locality { get; set; }
        public string? City { get; set; }
        public string? RegionCode { get; set; }
        public int CountryId { get; set; }
        public string? PostalCode { get; set; }
        public virtual Country Country { get; set; }
        public virtual ICollection<CustomerAddress> CustomerAddresses { get; set; }
    }
}
