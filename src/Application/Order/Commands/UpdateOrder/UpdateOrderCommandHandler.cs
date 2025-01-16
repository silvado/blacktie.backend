using Application.Abstractions.Messaging;
using Domain.Interfaces.Service;
using Domain.Models;
using Mapster;

namespace Application.Commands.UpdateOrder
{
    public class UpdateOrderCommandHandler : ICommandHandler<UpdateOrderCommand, bool>
    {
        private readonly IOrderService _service;


        public UpdateOrderCommandHandler(IOrderService service)
        {
            _service = service;
        }

        public async Task<bool> Handle(UpdateOrderCommand request, CancellationToken cancellationToken)
        {

            var r = request.item.Adapt<Order>();

            return (await _service.UpdateAsync(r));

        }
    }
}
