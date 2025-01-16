using Application.Abstractions.Messaging;
using Domain.Interfaces.Service;

namespace Application.Commands.DeleteTransport
{
    public class DeleteTransportCommandHandler : ICommandHandler<DeleteTransportCommand, bool>
    {
        private readonly ITransportService _service;

        public DeleteTransportCommandHandler(ITransportService service)
        {
            _service = service;
        }

        public async Task<bool> Handle(DeleteTransportCommand request, CancellationToken cancellationToken)
        {

            return await _service.DeleteAsync(request.id);

        }
    }
}
