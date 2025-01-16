using Application.Abstractions.Messaging;
using Domain.Interfaces.Service;

namespace Application.Commands.DeleteUnavailableDate
{
    public class DeleteUnavailableDateCommandHandler : ICommandHandler<DeleteUnavailableDateCommand, bool>
    {
        private readonly IUnavailableDateService _service;

        public DeleteUnavailableDateCommandHandler(IUnavailableDateService service)
        {
            _service = service;
        }

        public async Task<bool> Handle(DeleteUnavailableDateCommand request, CancellationToken cancellationToken)
        {

            return await _service.DeleteAsync(request.id);

        }
    }
}
