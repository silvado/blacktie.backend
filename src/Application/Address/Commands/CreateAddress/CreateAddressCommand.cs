using Application.Abstractions.Messaging;
using Application.Contracts.Address;

namespace Application.Commands.CreateAddress
{
    public sealed record CreateAddressCommand(AddressDto item) : ICommand<AddressDto>;
}
