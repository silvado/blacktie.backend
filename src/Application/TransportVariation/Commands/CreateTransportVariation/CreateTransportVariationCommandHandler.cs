using Application.Abstractions.Messaging;
using Domain.Interfaces.Service;
using Domain.Models;
using Mapster;

namespace Application.Commands.CreateTransportVariation
{

    public class CreateTransportVariationCommandHandler : ICommandHandler<CreateTransportVariationCommand, bool>
    {
        private readonly ITransportVariationService _service;


        public CreateTransportVariationCommandHandler(ITransportVariationService service)
        {
            _service = service;
        }

        public async Task<bool> Handle(CreateTransportVariationCommand request, CancellationToken cancellationToken)
        {
            var r = request.item.Adapt<TransportVariation>();

            return (await _service.CreateAsync(r));
        }
    }
}
