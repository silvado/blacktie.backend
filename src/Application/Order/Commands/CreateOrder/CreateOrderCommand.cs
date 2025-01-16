using Application.Abstractions.Messaging;
using Application.Contracts.Order;

namespace Application.Commands.CreateOrder
{
    public sealed record CreateOrderCommand(OrderPostDto item) : ICommand<OrderDto>;
}
