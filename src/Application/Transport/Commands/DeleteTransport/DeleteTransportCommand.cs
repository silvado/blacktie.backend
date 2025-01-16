using Application.Abstractions.Messaging;

namespace Application.Commands.DeleteTransport
{
    public sealed record DeleteTransportCommand(Guid id) : ICommand<bool>;
}
