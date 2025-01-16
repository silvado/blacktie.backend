using Application.Abstractions.Messaging;
using Domain.Interfaces.Service;

namespace Application.Commands.DeleteOrder
{
    public class DeleteOrderCommandHandler : ICommandHandler<DeleteOrderCommand, bool>
    {
        private readonly IOrderService _service;

        public DeleteOrderCommandHandler(IOrderService service)
        {
            _service = service;
        }

        public async Task<bool> Handle(DeleteOrderCommand request, CancellationToken cancellationToken)
        {

            return await _service.DeleteAsync(request.id);

        }
    }
}
