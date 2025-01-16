using Application.Contracts.DocumentType;

namespace Application.Contracts.Customer
{
    public class CreateCustomerDto
    {
        public Guid? Id { get; set; }
        public string? Name { get; set; }
        public string? Email { get; set; }
        public int CountryId { get; set; }
        public string? TaxId { get; set; }
        public string? Phone { get; set; }
        public DocumentTypeDto? DocumentType { get; set; }
        public List<CreateEnderecoDto>? Addresses { get; set; }
    }

    public class CreateEnderecoDto: DtoBaseInt
    {        
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
