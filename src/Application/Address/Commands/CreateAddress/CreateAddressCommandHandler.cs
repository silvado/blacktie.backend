using Application.Abstractions.Messaging;
using Application.Contracts.Address;
using Domain.Interfaces.Service;
using Domain.Models;
using Mapster;

namespace Application.Commands.CreateAddress
{
    public class CreateAddressCommandHandler : ICommandHandler<CreateAddressCommand, AddressDto>
    {
        private readonly IAddressService _service;


        public CreateAddressCommandHandler(IAddressService service)
        {
            _service = service;
        }

        public async Task<AddressDto> Handle(CreateAddressCommand request, CancellationToken cancellationToken)
        {

            var r = request.item.Adapt<Address>();

            return (await _service.CreateAddressAsync(r)).Adapt<AddressDto>();

        }
    }
}
