using Application.Abstractions.Messaging;
using Application.Contracts.Transport;

namespace Application.Queries.GetTransportVariationById
{
    public sealed record GetTransportVariationByIdQuery(int id) : IQuery<TransportVariationDto?>;
}
