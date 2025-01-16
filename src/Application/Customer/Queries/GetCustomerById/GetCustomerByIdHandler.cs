using Application.Abstractions.Messaging;
using Application.Contracts.Customer;
using Domain.Interfaces.Service;
using Mapster;

namespace Application.Queries.GetCustomerById
{
    public class GetCustomerByIdHandler : IQueryHandler<GetCustomerByIdQuery, CustomerDto?>
    {
        private readonly ICustomerService _service;

        public GetCustomerByIdHandler(ICustomerService service)
        {
            _service = service;
        }

        public async Task<CustomerDto?> Handle(GetCustomerByIdQuery request, CancellationToken cancellationToken)
        {
            var result = await _service.GetByIdAsync(request.id);

            if (result == null)
                return null;


            var mapped = result.Adapt<CustomerDto>();

            return mapped;
        }
    }
}
