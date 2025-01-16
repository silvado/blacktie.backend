using Application.Abstractions.Messaging;
using Domain.Interfaces.Service;
using Domain.Models;
using Mapster;

namespace Application.Commands.UpdateTransport
{
    public class UpdateTransportCommandHandler : ICommandHandler<UpdateTransportCommand, bool>
    {
        private readonly ITransportService _service;


        public UpdateTransportCommandHandler(ITransportService service)
        {
            _service = service;
        }

        public async Task<bool> Handle(UpdateTransportCommand request, CancellationToken cancellationToken)
        {

            var r = request.item.Adapt<Transport>();

            return (await _service.UpdateAsync(r));

        }
    }
}
