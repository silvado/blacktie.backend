using Application.Abstractions.Messaging;
using Application.Contracts.Transport;
using Domain.Interfaces.Service;
using Mapster;

namespace Application.Queries.GetTransportById
{
    public class GetTransportByIdHandler : IQueryHandler<GetTransportByIdQuery, TransportDto?>
    {
        private readonly ITransportService _service;

        public GetTransportByIdHandler(ITransportService service)
        {
            _service = service;
        }

        public async Task<TransportDto?> Handle(GetTransportByIdQuery request, CancellationToken cancellationToken)
        {
            var result = await _service.GetByIdAsync(request.id);

            if (result == null)
                return null;

            var mapped = result.Adapt<TransportDto>();

            return mapped;
        }
    }
}
