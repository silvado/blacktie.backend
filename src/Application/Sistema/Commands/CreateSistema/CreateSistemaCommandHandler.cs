using Application.Abstractions.Messaging;
using Application.Contracts.Sistema;
using Domain.Interfaces.Service;
using Domain.Models;
using Mapster;

namespace Application.Commands.CreateSistema
{

    public class CreateSistemaCommandHandler : ICommandHandler<CreateSistemaCommand, SistemaCadastroDto>
    {
        private readonly ISistemaService _service;


        public CreateSistemaCommandHandler(ISistemaService service)
        {
            _service = service;
        }

        public async Task<SistemaCadastroDto> Handle(CreateSistemaCommand request, CancellationToken cancellationToken)
        {

            var r = request.item.Adapt<Sistema>();

            return (await _service.CreateSistemaAsync(r)).Adapt<SistemaCadastroDto>();

        }
    }

}
