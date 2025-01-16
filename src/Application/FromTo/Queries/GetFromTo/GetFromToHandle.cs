using Application.Abstractions.Messaging;
using Application.Contracts.FromTo;
using Domain.Filters;
using Domain.Helpers;
using Domain.Interfaces.Service;
using Mapster;

namespace Application.Queries.GetFromTo
{
    public class GetFromToHandler : IQueryHandler<GetFromToQuery, PagedList<FromToDto>?>
    {
        private readonly IFromToService _service;

        public GetFromToHandler(IFromToService service)
        {
            _service = service;
        }

        public async Task<PagedList<FromToDto>?> Handle(GetFromToQuery request, CancellationToken cancellationToken)
        {
            var filter = request.parameters.Adapt<GenericFilter>();
            var result = await _service.GetFilteredAsync(filter);

            if (result == null)
                return null;

            var mapped = result.Data.Adapt<List<FromToDto>>();
            return new PagedList<FromToDto>(mapped, result.TotalCount, request.parameters.PageNumber, request.parameters.PageSize);
        }
    }
}
