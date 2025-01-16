using Application.Abstractions.Messaging;
using Domain.Interfaces.Service;
using Mapster;

namespace Application.Commands.UpdateSistema
{
    public class UpdateSistemaCommandHandler : ICommandHandler<UpdateSistemaCommand, bool>
    {
        private readonly ISistemaService _service;

        public UpdateSistemaCommandHandler(ISistemaService service)
        {
            _service = service;
        }

        public async Task<bool> Handle(UpdateSistemaCommand request, CancellationToken cancellationToken)
        {
            var entity = await _service.GetSistemaByIdAsync(request.item.Id);

            request.item.Adapt(entity);

            return await _service.UpdateSistemaAsync(entity!);

        }
    }
}
