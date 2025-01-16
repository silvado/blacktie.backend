using Application.Abstractions.Messaging;
using Application.Commands.DeleteFromTo;
using Domain.Interfaces.Service;

namespace Application.Commands.DeleteProductPricing
{
    public class DeleteFromToCommandHandler : ICommandHandler<DeleteFromToCommand, bool>
    {
        private readonly IFromToService _service;

        public DeleteFromToCommandHandler(IFromToService service)
        {
            _service = service;
        }

        public async Task<bool> Handle(DeleteFromToCommand request, CancellationToken cancellationToken)
        {

            return await _service.DeleteAsync(request.id);

        }
    }
}
