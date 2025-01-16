using Application.Abstractions.Messaging;
using Application.Contracts.Transport;

namespace Application.Queries.GetTransportById
{
    public sealed record GetTransportByIdQuery(Guid id) : IQuery<TransportDto?>;
}
