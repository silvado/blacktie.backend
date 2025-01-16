using Application.Abstractions.Messaging;
using Application.Contracts.Address;
using Domain.Filters;
using Domain.Helpers;
using Domain.Interfaces.Service;
using Mapster;

namespace Application.Queries.GetAddress
{
    public class GetAddressHandler : IQueryHandler<GetAddressQuery, PagedList<AddressDto>?>
    {
        private readonly IAddressService _service;

        public GetAddressHandler(IAddressService service)
        {
            _service = service;
        }

        public async Task<PagedList<AddressDto>?> Handle(GetAddressQuery request, CancellationToken cancellationToken)
        {
            var filter = request.parameters.Adapt<AddressFilter>();
            var result = await _service.GetFilteredAsync(filter);

            if (result == null)
                return null;

            var mapped = result.Data.Adapt<List<AddressDto>>();
            return new PagedList<AddressDto>(mapped, result.TotalCount, request.parameters.PageNumber, request.parameters.PageSize);
        }
    }
}
