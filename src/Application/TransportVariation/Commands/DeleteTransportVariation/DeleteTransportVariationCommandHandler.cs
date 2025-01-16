using Application.Abstractions.Messaging;
using Domain.Interfaces.Service;

namespace Application.Commands.DeleteTransportVariation
{
    public class DeleteTransportVariationCommandHandler : ICommandHandler<DeleteTransportVariationCommand, bool>
    {
        private readonly ITransportVariationService _service;

        public DeleteTransportVariationCommandHandler(ITransportVariationService service)
        {
            _service = service;
        }

        public async Task<bool> Handle(DeleteTransportVariationCommand request, CancellationToken cancellationToken)
        {

            return await _service.DeleteAsync(request.id);

        }
    }
}
