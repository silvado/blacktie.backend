using Application.Abstractions.Messaging;
using Application.Contracts.Address;
using Domain.Interfaces.Service;
using Mapster;

namespace Application.Queries.GetAddressById
{
    public class GetAddressByIdHandler : IQueryHandler<GetAddressByIdQuery, AddressDto?>
    {
        private readonly IAddressService _service;

        public GetAddressByIdHandler(IAddressService service)
        {
            _service = service;
        }

        public async Task<AddressDto?> Handle(GetAddressByIdQuery request, CancellationToken cancellationToken)
        {
            var result = await _service.GetAddressByIdAsync(request.id);

            if (result == null)
                return null;


            var mapped = result.Adapt<AddressDto>();

            return result.Adapt<AddressDto>();
        }
    }
}
