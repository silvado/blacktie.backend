using Application.Contracts.DocumentType;

namespace Application.Contracts.Customer
{
    public class UpdateCustomerDto
    {
        public Guid Id { get; set; }
        public string? Name { get; set; }
        public string? Email { get; set; }
        public int CountryId { get; set; }
        public int DocumentTypeId { get; set; }
        public string? TaxId { get; set; }
        public string? Phone { get; set; }        
        public List<CreateEnderecoDto>? Addresses { get; set; }
    }
}
