using Application.Abstractions.Messaging;
using Application.Contracts.Transport;

namespace Application.Commands.UpdateTransportVariation
{
    public sealed record UpdateTransportVariationCommand(TransportVariationDto item) : ICommand<bool>;
}
