using Application.Abstractions.Messaging;
using Application.Contracts;
using Domain.Filters;
using Domain.Helpers;
using Domain.Interfaces.Service;
using Mapster;

namespace Application.Queries.GetSistemaPublicacao
{

    public class GetSistemaPublicacaoHandler : IQueryHandler<GetSistemaPublicacaoQuery, PagedList<SistemaPublicacaoDto>?>
    {
        private readonly ISistemaPublicacaoService _service;

        public GetSistemaPublicacaoHandler(ISistemaPublicacaoService service)
        {
            _service = service;
        }

        public async Task<PagedList<SistemaPublicacaoDto>?> Handle(GetSistemaPublicacaoQuery request, CancellationToken cancellationToken)
        {
            var filter = request.parameters.Adapt<SistemaPublicacaoFilter>();
            var result = await _service.GetFilteredAsync(filter);

            if (result == null)
                return null;

            var mapped = result.Data.Adapt<List<SistemaPublicacaoDto>>();
            return new PagedList<SistemaPublicacaoDto>(mapped, result.TotalCount, request.parameters.PageNumber, request.parameters.PageSize);
        }
    }
}
