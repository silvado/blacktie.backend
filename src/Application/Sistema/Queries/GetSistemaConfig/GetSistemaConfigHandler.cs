using Application.Abstractions.Messaging;
using Application.Contracts.Sistema;
using Domain.Exceptions;
using Domain.Interfaces.Service;
using Mapster;
using Newtonsoft.Json;

namespace Application.Queries.GetSistemaConfig
{
    public class GetSistemaConfigHandler : IQueryHandler<GetSistemaConfigQuery, SistemaConfigDto?>
    {
        private readonly ISistemaService _service;

        public GetSistemaConfigHandler(ISistemaService service)
        {
            _service = service;
        }

        public async Task<SistemaConfigDto?> Handle(GetSistemaConfigQuery request, CancellationToken cancellationToken)
        {
            var result = await _service.GetSistemaBySiglaAsync();

            if (result == null)
                return null;

            

            if (result.Configuracao is null)
                throw new BlacktieNotAcceptableException("Sistema sem configuração cadastrada.");

            var mapped = result.Adapt<SistemaConfigDto>();


            if (result.Configuracao is not null)
            {
                var validJson = _service.IsValidJson(result.Configuracao);

                if (validJson)
                {
                    mapped.Configuracao = JsonConvert.DeserializeObject(result.Configuracao!);
                }
                else
                {
                    throw new BlacktieNotAcceptableException("Sistema com configuração inválida.");
                }
            }

            mapped.Configuracao = JsonConvert.DeserializeObject<Dictionary<string, object>>(result.Configuracao!);

            return result.Adapt<SistemaConfigDto>();
        }
    }
}
