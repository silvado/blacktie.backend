using Application.Abstractions.Messaging;
using Domain.Interfaces.Service;

namespace Application.Commands.DeleteCustomer
{
    public class DeleteCustomerCommandHandler : ICommandHandler<DeleteCustomerCommand, bool>
    {
        private readonly ICustomerService _service;

        public DeleteCustomerCommandHandler(ICustomerService service)
        {
            _service = service;
        }

        public async Task<bool> Handle(DeleteCustomerCommand request, CancellationToken cancellationToken)
        {

            await _service.DeleteAsync(request.Id);


            return true;

        }
    }
}
