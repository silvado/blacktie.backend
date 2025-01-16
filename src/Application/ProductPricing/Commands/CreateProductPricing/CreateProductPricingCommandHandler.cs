using Application.Abstractions.Messaging;
using Application.Contracts.Product;
using Domain.Interfaces.Service;
using Domain.Models;
using Mapster;

namespace Application.Commands.CreateProductPricing
{
    public class CreateProductPricingCommandHandler : ICommandHandler<CreateProductPricingCommand, ProductPricingDto>
    {
        private readonly IProductPricingService _service;


        public CreateProductPricingCommandHandler(IProductPricingService service)
        {
            _service = service;
        }

        public async Task<ProductPricingDto> Handle(CreateProductPricingCommand request, CancellationToken cancellationToken)
        {
            var r = request.item.Adapt<ProductPricing>();

            var p = await _service.CreateAsync(r);

            return (await _service.GetByIdAsync(p.Id)).Adapt<ProductPricingDto>();
        }
    }
}
