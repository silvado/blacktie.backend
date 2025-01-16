using Application.Abstractions.Messaging;
using Application.Contracts.Order;

namespace Application.Commands.UpdateOrder
{
    public sealed record UpdateOrderCommand(OrderDto item) : ICommand<bool>;
}
