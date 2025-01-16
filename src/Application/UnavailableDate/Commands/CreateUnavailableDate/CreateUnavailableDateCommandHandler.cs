using Application.Abstractions.Messaging;
using Application.Contracts.UnavailableDate;
using Domain.Interfaces.Service;
using Domain.Models;
using Mapster;

namespace Application.Commands.CreateUnavailableDate
{
    public class CreateUnavailableDateCommandHandler : ICommandHandler<CreateUnavailableDateCommand, UnavailableDateDto>
    {
        private readonly IUnavailableDateService _service;


        public CreateUnavailableDateCommandHandler(IUnavailableDateService service)
        {
            _service = service;
        }

        public async Task<UnavailableDateDto> Handle(CreateUnavailableDateCommand request, CancellationToken cancellationToken)
        {
            var r = request.item.Adapt<UnavailableDate>();

            var p = await _service.CreateAsync(r);

            return (await _service.GetByIdAsync(p.Id)).Adapt<UnavailableDateDto>();
        }
    }
}
