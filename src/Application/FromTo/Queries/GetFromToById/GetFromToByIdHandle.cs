using Application.Abstractions.Messaging;
using Application.Contracts.FromTo;
using Domain.Interfaces.Service;
using Mapster;

namespace Application.Queries.GetFromToById
{
    public class GetFromToByIdHandle : IQueryHandler<GetFromToByIdQuery, FromToDto?>
    {
        private readonly IFromToService _service;

        public GetFromToByIdHandle(IFromToService service)
        {
            _service = service;
        }

        public async Task<FromToDto?> Handle(GetFromToByIdQuery request, CancellationToken cancellationToken)
        {
            var result = await _service.GetByIdAsync(request.id);

            if (result == null)
                return null;

            var mapped = result.Adapt<FromToDto>();

            return mapped;
        }
    }
}
