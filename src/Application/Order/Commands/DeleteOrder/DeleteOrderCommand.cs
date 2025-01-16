using Application.Abstractions.Messaging;

namespace Application.Commands.DeleteOrder
{
    public sealed record DeleteOrderCommand(Guid id) : ICommand<bool>;
}
