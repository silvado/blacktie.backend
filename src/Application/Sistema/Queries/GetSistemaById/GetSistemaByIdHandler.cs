using Application.Abstractions.Messaging;
using Application.Contracts;
using Domain.Interfaces.Service;
using Mapster;
using Newtonsoft.Json;

namespace Application.Queries.GetSistemaById
{
    public class GetSistemaByIdHandler : IQueryHandler<GetSistemaByIdQuery, SistemaDto?>
    {
        private readonly ISistemaService _service;

        public GetSistemaByIdHandler(ISistemaService service)
        {
            _service = service;
        }

        public async Task<SistemaDto?> Handle(GetSistemaByIdQuery request, CancellationToken cancellationToken)
        {
            var result = await _service.GetSistemaByIdAsync(request.id);

            if (result == null || result.Id == 0)
                return null;


            var mapped = result.Adapt<SistemaDto>();

            if (result.Configuracao is not null)
            {
                var validJson = _service.IsValidJson(result.Configuracao);

                if (validJson)
                {
                    mapped.Configuracao = JsonConvert.DeserializeObject(result.Configuracao!);
                }
                else
                {
                    mapped.Configuracao = null;
                }
            }

            return result.Adapt<SistemaDto>();
        }


    }
}
