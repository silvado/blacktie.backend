using Application.Abstractions.Messaging;
using Application.Contracts.Transport;
using Domain.Interfaces.Service;
using Mapster;

namespace Application.Queries.GetTransportVariationById
{
    public class GetTransportVariationByIdHandler : IQueryHandler<GetTransportVariationByIdQuery, TransportVariationDto?>
    {
        private readonly ITransportVariationService _service;

        public GetTransportVariationByIdHandler(ITransportVariationService service)
        {
            _service = service;
        }

        public async Task<TransportVariationDto?> Handle(GetTransportVariationByIdQuery request, CancellationToken cancellationToken)
        {
            var result = await _service.GetByIdAsync(request.id);

            if (result == null)
                return null;

            var mapped = result.Adapt<TransportVariationDto>();

            return mapped;
        }


    }
}
