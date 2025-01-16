using Application.Abstractions.Messaging;
using Domain.Interfaces.Service;
using Domain.Models;
using Mapster;

namespace Application.Commands.UpdateUnavailableDate
{
    public class UpdateUnavailableDateCommandHandler : ICommandHandler<UpdateUnavailableDateCommand, bool>
    {
        private readonly IUnavailableDateService _service;


        public UpdateUnavailableDateCommandHandler(IUnavailableDateService service)
        {
            _service = service;
        }

        public async Task<bool> Handle(UpdateUnavailableDateCommand request, CancellationToken cancellationToken)
        {

            var r = request.item.Adapt<UnavailableDate>();

            return (await _service.UpdateAsync(r));

        }
    }
}
