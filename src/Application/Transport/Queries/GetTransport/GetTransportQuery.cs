using Application.Abstractions.Messaging;
using Application.Contracts.Transport;
using Domain.Helpers;

namespace Application.Queries.GetTransport
{
    public sealed record GetTransportQuery(GetTransportParameters parameters) : IQuery<PagedList<TransportDto>?>;
}
