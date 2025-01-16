using Application.Abstractions.Messaging;
using Domain.Interfaces.Service;

namespace Application.Commands.DeleteAddress
{

    public class DeleteAddressCommandHandler : ICommandHandler<DeleteAddressCommand, bool>
    {
        private readonly IAddressService _service;


        public DeleteAddressCommandHandler(IAddressService service)
        {
            _service = service;
        }

        public async Task<bool> Handle(DeleteAddressCommand request, CancellationToken cancellationToken)
        {

            return await _service.DeleteAddressAsync(request.id);

        }
    }
}
