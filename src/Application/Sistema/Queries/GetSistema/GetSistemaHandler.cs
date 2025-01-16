using Application.Abstractions.Messaging;
using Application.Contracts;
using Domain.Filters;
using Domain.Helpers;
using Domain.Interfaces.Service;
using Mapster;

namespace Application.Queries.GetSistema
{  

    public class GetSistemaHandler : IQueryHandler<GetSistemaQuery, PagedList<SistemaDto>?>
    {
        private readonly ISistemaService _service;

        public GetSistemaHandler(ISistemaService service)
        {
            _service = service;
        }

        public async Task<PagedList<SistemaDto>?> Handle(GetSistemaQuery request, CancellationToken cancellationToken)
        {
            var filter = request.parameters.Adapt<SistemaFilter>();
            var result = await _service.GetFilteredAsync(filter);

            if (result == null)
                return null;

            var mapped = result.Data.Adapt<List<SistemaDto>>();
            return new PagedList<SistemaDto>(mapped, result.TotalCount, request.parameters.PageNumber, request.parameters.PageSize);            
        }
    }
}
