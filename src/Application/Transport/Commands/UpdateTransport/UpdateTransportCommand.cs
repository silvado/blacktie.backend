using Application.Abstractions.Messaging;
using Application.Contracts.Transport;

namespace Application.Commands.UpdateTransport
{
    public sealed record UpdateTransportCommand(TransportDto item) : ICommand<bool>;
}
