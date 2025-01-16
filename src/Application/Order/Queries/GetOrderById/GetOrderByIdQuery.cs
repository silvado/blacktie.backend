using Application.Abstractions.Messaging;
using Application.Contracts.Order;

namespace Application.Queries.GetOrderById
{
    public sealed record GetOrderByIdQuery(Guid id) : IQuery<OrderDto?>;
}
