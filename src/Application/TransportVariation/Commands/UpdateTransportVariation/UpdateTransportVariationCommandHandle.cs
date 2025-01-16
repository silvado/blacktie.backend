using Application.Abstractions.Messaging;
using Domain.Interfaces.Service;
using Domain.Models;
using Mapster;

namespace Application.Commands.UpdateTransportVariation
{
    public class UpdateTransportVariationCommandHandler : ICommandHandler<UpdateTransportVariationCommand, bool>
    {
        private readonly ITransportVariationService _service;


        public UpdateTransportVariationCommandHandler(ITransportVariationService service)
        {
            _service = service;
        }

        public async Task<bool> Handle(UpdateTransportVariationCommand request, CancellationToken cancellationToken)
        {

            var r = request.item.Adapt<TransportVariation>();

            return (await _service.UpdateAsync(r));

        }
    }
}
