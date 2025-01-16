using Application.Abstractions.Messaging;
using Application.Contracts;
using Domain.Interfaces.Service;
using Mapster;

namespace Application.Queries.GetSistemaPublicacaoById
{
    public class GetSistemaPublicacaoByIdHandler : IQueryHandler<GetSistemaPublicacaoByIdQuery, SistemaPublicacaoDto?>
    {
        private readonly ISistemaPublicacaoService _service;

        public GetSistemaPublicacaoByIdHandler(ISistemaPublicacaoService service)
        {
            _service = service;
        }

        public async Task<SistemaPublicacaoDto?> Handle(GetSistemaPublicacaoByIdQuery request, CancellationToken cancellationToken)
        {
            var result = await _service.GetByIdAsync(request.id);

            if (result == null || result.Id == 0)
                return null;

            return result.Adapt<SistemaPublicacaoDto>();
        }
    }
}
