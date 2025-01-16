using Application.Abstractions.Messaging;
using Application.Contracts.Transport;
using Domain.Interfaces.Service;
using Domain.Models;
using Mapster;

namespace Application.Commands.CreateTransport
{
    public class CreateTransportCommandHandler : ICommandHandler<CreateTransportCommand, TransportDto>
    {
        private readonly ITransportService _service;


        public CreateTransportCommandHandler(ITransportService service)
        {
            _service = service;
        }

        public async Task<TransportDto> Handle(CreateTransportCommand request, CancellationToken cancellationToken)
        {
            var r = request.item.Adapt<Transport>();

            return (await _service.CreateAsync(r)).Adapt<TransportDto>();
        }
    }
}
