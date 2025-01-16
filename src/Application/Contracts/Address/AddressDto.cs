using Domain.Models;

namespace Application.Contracts.Address
{
    public class AddressDto
    {
        public int Id { get; set; }
        public string? Street { get; set; }
        public string? Number { get; set; }
        public string? Complement { get; set; }
        public string? Locality { get; set; }
        public string? City { get; set; }
        public string? RegionCode { get; set; }
        public int CountryId { get; set; }
        public string? PostalCode { get; set; }        
    }
}
