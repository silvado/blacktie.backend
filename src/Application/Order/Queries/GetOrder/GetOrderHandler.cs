using Application.Abstractions.Messaging;
using Application.Contracts.Order;
using Domain.Filters;
using Domain.Helpers;
using Domain.Interfaces.Service;
using Mapster;

namespace Application.Queries.GetOrder
{
    public class GetOrderHandler : IQueryHandler<GetOrderQuery, PagedList<OrderDto>?>
    {
        private readonly IOrderService _service;

        public GetOrderHandler(IOrderService service)
        {
            _service = service;
        }

        public async Task<PagedList<OrderDto>?> Handle(GetOrderQuery request, CancellationToken cancellationToken)
        {
            var filter = request.parameters.Adapt<OrderFilter>();

            filter.IsDeleted = false;

            var result = await _service.GetFilteredAsync(filter);

            if (result == null)
                return null;

            var mapped = result.Data.Adapt<List<OrderDto>>();
            return new PagedList<OrderDto>(mapped, result.TotalCount, request.parameters.PageNumber, request.parameters.PageSize);
        }
    }
}
