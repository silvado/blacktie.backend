using Application.Abstractions.Messaging;
using Application.Contracts.Address;
using Domain.Interfaces.Service;
using Domain.Models;
using Mapster;

namespace Application.Commands.UpdateAddress
{
    public class UpdateAddressCommandHandler : ICommandHandler<UpdateAddressCommand, bool>
    {
        private readonly IAddressService _service;


        public UpdateAddressCommandHandler(IAddressService service)
        {
            _service = service;
        }

        public async Task<bool> Handle(UpdateAddressCommand request, CancellationToken cancellationToken)
        {

            var r = request.item.Adapt<Address>();

            return (await _service.UpdateAddressAsync(r));

        }
    }
}
