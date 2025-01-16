using Application.Abstractions.Messaging;
using Application.Contracts.Transport;

namespace Application.Commands.CreateTransportVariation
{
    public sealed record CreateTransportVariationCommand(TransportVariationDto item) : ICommand<bool>;
}
