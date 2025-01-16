using Application.Abstractions.Messaging;
using Application.Contracts.PaymentType;
using Domain.Interfaces.Service;
using Domain.Models;
using Mapster;

namespace Application.Commands.CreatePaymentType
{
    public class CreatePaymentTypeCommandHandler : ICommandHandler<CreatePaymentTypeCommand, PaymentTypeDto>
    {
        private readonly IPaymentTypeService _service;


        public CreatePaymentTypeCommandHandler(IPaymentTypeService service)
        {
            _service = service;
        }

        public async Task<PaymentTypeDto> Handle(CreatePaymentTypeCommand request, CancellationToken cancellationToken)
        {
            var r = request.item.Adapt<PaymentType>();

            var p = await _service.CreateAsync(r);

            return (await _service.GetByIdAsync(p.Id)).Adapt<PaymentTypeDto>();
        }
    }
}
