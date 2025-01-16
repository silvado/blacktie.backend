using Application.Abstractions.Messaging;
using Application.Contracts.Address;
using Domain.Helpers;

namespace Application.Queries.GetAddress
{
    public sealed record GetAddressQuery(GetAddressParameters parameters) : IQuery<PagedList<AddressDto>?>;
}
