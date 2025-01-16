using Application.Abstractions.Messaging;
using Application.Contracts.Address;

namespace Application.Queries.GetAddressById
{
    public sealed record GetAddressByIdQuery(int id) : IQuery<AddressDto?>;

}
