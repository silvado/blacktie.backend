using Application.Abstractions.Messaging;
using Domain.Interfaces.Service;
using Domain.Models;
using Mapster;

namespace Application.Commands.PublishSistema
{
    public class PublishSistemaCommandHandler : ICommandHandler<PublishSistemaCommand, bool>
    {
        private readonly ISistemaService _service;

        public PublishSistemaCommandHandler(ISistemaService service)
        {
            _service = service;
        }

        public async Task<bool> Handle(PublishSistemaCommand request, CancellationToken cancellationToken)
        {
            var entity = await _service.GetSistemaByIdAsync(request.item.Id);

            request.item.Adapt(entity);

            return await _service.PublishSistemaAsync(entity!);

        }
    }
}
