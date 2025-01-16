using Application.Abstractions.Messaging;
using Application.Contracts.Country;
using Domain.Filters;
using Domain.Helpers;
using Domain.Interfaces.Service;
using Mapster;

namespace Application.Queries.GetCountry
{
    public class GetCountryHandler : IQueryHandler<GetCountryQuery, PagedList<CountryDto>?>
    {
        private readonly ICountryService _service;

        public GetCountryHandler(ICountryService service)
        {
            _service = service;
        }

        public async Task<PagedList<CountryDto>?> Handle(GetCountryQuery request, CancellationToken cancellationToken)
        {
            var filter = request.parameters.Adapt<CountryFilter>();
            var result = await _service.GetFilteredAsync(filter);

            if (result == null)
                return null;

            var mapped = result.Data.Adapt<List<CountryDto>>();
            return new PagedList<CountryDto>(mapped, result.TotalCount, request.parameters.PageNumber, request.parameters.PageSize);
        }
    }
}
