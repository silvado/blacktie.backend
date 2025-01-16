using Application.Abstractions.Messaging;
using Domain.Interfaces.Service;
using Domain.Models;
using Mapster;

namespace Application.Commands.UpdateProductPricing
{
    public class UpdateProductPricingCommandHandler : ICommandHandler<UpdateProductPricingCommand, bool>
    {
        private readonly IProductPricingService _service;


        public UpdateProductPricingCommandHandler(IProductPricingService service)
        {
            _service = service;
        }

        public async Task<bool> Handle(UpdateProductPricingCommand request, CancellationToken cancellationToken)
        {

            var r = request.item.Adapt<ProductPricing>();

            return (await _service.UpdateAsync(r));

        }
    }
}
