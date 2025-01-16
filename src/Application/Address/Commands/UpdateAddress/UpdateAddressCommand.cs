using Application.Abstractions.Messaging;
using Application.Contracts.Address;

namespace Application.Commands.UpdateAddress
{  
    public sealed record UpdateAddressCommand(AddressDto item) : ICommand<bool>;
}
