using Application.Contracts.Address;
using Domain.Models;

namespace Application.Contracts.Customer
{
    public class CustomerDto
    {
        public Guid? Id { get; set; }
        public string? Name { get; set; }
        public string? Email { get; set; }
        public int CountryId { get; set; }
        public int DocumentTypeId { get; set; }
        public string? TaxId { get; set; }
        public string? Phone { get; set; }
        public int? TempControle { get; set; }
        public Guid? UserId { get; set; }
        //public IEnumerable<AddressDto>? Addresses { get; set; }
    }
}
