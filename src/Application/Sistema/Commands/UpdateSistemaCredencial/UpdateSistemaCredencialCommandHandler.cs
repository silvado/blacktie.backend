using Application.Abstractions.Messaging;
using Application.Contracts.Sistema;
using Domain.Interfaces.Service;
using Mapster;

namespace Application.Commands.UpdateSistemaCredencial
{
    public class UpdateSistemaCredencialCommandHandler : ICommandHandler<UpdateSistemaCredencialCommand, SistemaCadastroDto>
    {
        private readonly ISistemaService _service;

        public UpdateSistemaCredencialCommandHandler(ISistemaService service)
        {
            _service = service;
        }

        public async Task<SistemaCadastroDto> Handle(UpdateSistemaCredencialCommand request, CancellationToken cancellationToken)
        {
            var entity = await _service.GetSistemaByIdAsync(request.item.Id);

            request.item.Adapt(entity);

            return (await _service.UpdateSistemaCredencialAsync(entity!)).Adapt<SistemaCadastroDto>();

        }
    }
}
