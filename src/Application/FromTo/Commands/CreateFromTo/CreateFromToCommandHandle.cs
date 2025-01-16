using Application.Abstractions.Messaging;
using Application.Commands.CreateFromTo;
using Application.Contracts.FromTo;
using Domain.Interfaces.Service;
using Domain.Models;
using Mapster;

namespace Application.Commands.CreateFromTo
{
    public class CreateFromToCommandHandler : ICommandHandler<CreateFromToCommand, FromToDto>
    {
        private readonly IFromToService _service;


        public CreateFromToCommandHandler(IFromToService service)
        {
            _service = service;
        }

        public async Task<FromToDto> Handle(CreateFromToCommand request, CancellationToken cancellationToken)
        {
            var r = request.item.Adapt<FromTo>();

            var p = await _service.CreateAsync(r);

            return (await _service.GetByIdAsync(p.Id)).Adapt<FromToDto>();
        }
    }
}
