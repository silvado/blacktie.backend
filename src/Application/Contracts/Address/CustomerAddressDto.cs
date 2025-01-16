using Application.Contracts.Customer;

namespace Application.Contracts.Address
{
    public class CustomerAddressDto
    {
        public CustomerDto? Customer { get; set; }
        public Guid CustomerId { get; set; }
        public AddressDto? Address { get; set; }
        public int AddressId { get; set; }
    }
}
