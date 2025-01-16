using Application.Abstractions.Messaging;
using Application.Contracts.Transport;
using Application.Queries.GetTransport;
using Domain.Filters;
using Domain.Helpers;
using Domain.Interfaces.Service;
using Mapster;

namespace Application.Queries.GetTransport
{
    public class GetTransportHandler : IQueryHandler<GetTransportQuery, PagedList<TransportDto>?>
    {
        private readonly ITransportService _service;

        public GetTransportHandler(ITransportService service)
        {
            _service = service;
        }

        public async Task<PagedList<TransportDto>?> Handle(GetTransportQuery request, CancellationToken cancellationToken)
        {
            var filter = request.parameters.Adapt<TransportFilter>();
            var result = await _service.GetFilteredAsync(filter);

            if (result == null)
                return null;

            var mapped = result.Data.Adapt<List<TransportDto>>();
            return new PagedList<TransportDto>(mapped, result.TotalCount, request.parameters.PageNumber, request.parameters.PageSize);
        }
    }
}
