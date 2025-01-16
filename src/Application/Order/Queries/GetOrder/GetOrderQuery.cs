using Application.Abstractions.Messaging;
using Application.Contracts.Order;
using Domain.Helpers;

namespace Application.Queries.GetOrder
{
    public sealed record GetOrderQuery(GetOrderParameters parameters) : IQuery<PagedList<OrderDto>?>;
}
