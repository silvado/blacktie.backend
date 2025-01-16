using Application.Abstractions.Messaging;
using Application.Contracts.Order;
using Domain.Interfaces.Service;
using Mapster;

namespace Application.Queries.GetOrderById
{
    public class GetOrderByIdHandle : IQueryHandler<GetOrderByIdQuery, OrderDto?>
    {
        private readonly IOrderService _service;

        public GetOrderByIdHandle(IOrderService service)
        {
            _service = service;
        }

        public async Task<OrderDto?> Handle(GetOrderByIdQuery request, CancellationToken cancellationToken)
        {
            var result = await _service.GetByIdAsync(request.id);

            if (result == null)
                return null;

            var mapped = result.Adapt<OrderDto>();

            return mapped;
        }
    }
}
