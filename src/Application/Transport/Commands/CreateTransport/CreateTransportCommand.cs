using Application.Abstractions.Messaging;
using Application.Contracts.Transport;

namespace Application.Commands.CreateTransport
{
    public sealed record CreateTransportCommand(TransportDto item) : ICommand<TransportDto>;
}
