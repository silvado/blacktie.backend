using Application.Abstractions.Messaging;
using Application.Contracts.Customer;
using Domain.Filters;
using Domain.Helpers;
using Domain.Interfaces.Service;
using Mapster;

namespace Application.Queries.GetCustomer
{
    public class GetCustomerHandler : IQueryHandler<GetCustomerQuery, PagedList<CustomerDto>?>
    {
        private readonly ICustomerService _service;

        public GetCustomerHandler(ICustomerService service)
        {
            _service = service;
        }

        public async Task<PagedList<CustomerDto>?> Handle(GetCustomerQuery request, CancellationToken cancellationToken)
        {
            var filter = request.parameters.Adapt<CustomerFilter>();
            var result = await _service.GetFilteredAsync(filter);

            if (result == null)
                return null;

            var mapped = result.Data.Adapt<List<CustomerDto>>();
            return new PagedList<CustomerDto>(mapped, result.TotalCount, request.parameters.PageNumber, request.parameters.PageSize);
        }
    }
}
