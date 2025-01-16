using Application.Abstractions.Messaging;
using Domain.Interfaces.Service;

namespace Application.Commands.DeleteSistema
{


    public class DeleteSistemaCommandHandler : ICommandHandler<DeleteSistemaCommand, bool>
    {
        private readonly ISistemaService _service;

        public DeleteSistemaCommandHandler(ISistemaService service)
        {
            _service = service;
        }

        public async Task<bool> Handle(DeleteSistemaCommand request, CancellationToken cancellationToken)
        {

            return await _service.DeleteSistemaAsync(request.id);

        }
    }
}
