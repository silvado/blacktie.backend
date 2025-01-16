using Application.Abstractions.Messaging;
using Application.Contracts.Customer;
using Domain.Interfaces.Service;
using Domain.Models;
using Mapster;

namespace Application.Commands.CreateCustomer
{
    public class CreateCustomerCommandHandler : ICommandHandler<CreateCustomerCommand, CustomerDto>
    {
        private readonly ICustomerService _service;


        public CreateCustomerCommandHandler(ICustomerService service)
        {
            _service = service;
        }

        public async Task<CustomerDto> Handle(CreateCustomerCommand request, CancellationToken cancellationToken)
        {

            var r = request.item.Adapt<Customer>();

            return (await _service.CreateAsync(r)).Adapt<CustomerDto>();

        }
    }
}
