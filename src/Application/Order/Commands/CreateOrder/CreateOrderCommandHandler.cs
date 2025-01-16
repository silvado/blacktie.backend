using Application.Abstractions.Messaging;
using Application.Contracts.Order;
using Domain.Interfaces.Service;
using Domain.Models;
using Mapster;

namespace Application.Commands.CreateOrder
{
    public class CreateOrderCommandHandler : ICommandHandler<CreateOrderCommand, OrderDto>
    {
        private readonly IOrderService _service;


        public CreateOrderCommandHandler(IOrderService service)
        {
            _service = service;
        }

        public async Task<OrderDto> Handle(CreateOrderCommand request, CancellationToken cancellationToken)
        {
            var r = request.item.Adapt<Order>();

            var p = await _service.CreateAsync(r, request.item.UserId);           

            return (await _service.GetByIdAsync(p.Id)).Adapt<OrderDto>();
        }
    }
}
