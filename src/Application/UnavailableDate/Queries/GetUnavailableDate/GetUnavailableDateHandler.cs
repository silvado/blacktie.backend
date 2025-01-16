using Application.Abstractions.Messaging;
using Application.Contracts.UnavailableDate;
using Domain.Filters;
using Domain.Helpers;
using Domain.Interfaces.Service;
using Mapster;

namespace Application.Queries.GetUnavailableDateByYear
{
    public class GetUnavailableDateHandler : IQueryHandler<GetUnavailableDateQuery, PagedList<UnavailableDateDto>?>
    {
        private readonly IUnavailableDateService _service;

        public GetUnavailableDateHandler(IUnavailableDateService service)
        {
            _service = service;
        }

        public async Task<PagedList<UnavailableDateDto>?> Handle(GetUnavailableDateQuery request, CancellationToken cancellationToken)
        {
            var filter = request.parameters.Adapt<UnavailableDateFilter>();
            var result = await _service.GetFilteredAsync(filter);

            if (result == null)
                return null;

            var mapped = result.Data.Adapt<List<UnavailableDateDto>>();
            return new PagedList<UnavailableDateDto>(mapped, result.TotalCount, request.parameters.PageNumber, request.parameters.PageSize);
        }
    }
}
