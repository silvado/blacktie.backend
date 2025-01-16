using Application.Abstractions.Messaging;
using Application.Commands.UpdateFromTo;
using Domain.Interfaces.Service;
using Domain.Models;
using Mapster;

namespace Application.Commands.UpdateFromTo
{
    public class UpdateFromToCommandHandler : ICommandHandler<UpdateFromToCommand, bool>
    {
        private readonly IFromToService _service;


        public UpdateFromToCommandHandler(IFromToService service)
        {
            _service = service;
        }

        public async Task<bool> Handle(UpdateFromToCommand request, CancellationToken cancellationToken)
        {

            var r = request.item.Adapt<FromTo>();

            return (await _service.UpdateAsync(r));

        }
    }
}
