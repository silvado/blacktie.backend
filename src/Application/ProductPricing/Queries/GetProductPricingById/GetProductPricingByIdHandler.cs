using Application.Abstractions.Messaging;
using Application.Contracts.Product;
using Domain.Interfaces.Service;
using Mapster;

namespace Application.Queries.GetProductPricingById
{
    public class GetProductPricingByIdHandle : IQueryHandler<GetProductPricingByIdQuery, ProductPricingDto?>
    {
        private readonly IProductPricingService _service;

        public GetProductPricingByIdHandle(IProductPricingService service)
        {
            _service = service;
        }

        public async Task<ProductPricingDto?> Handle(GetProductPricingByIdQuery request, CancellationToken cancellationToken)
        {
            var result = await _service.GetByIdAsync(request.id);

            if (result == null)
                return null;

            var mapped = result.Adapt<ProductPricingDto>();

            return mapped;
        }
    }
}
