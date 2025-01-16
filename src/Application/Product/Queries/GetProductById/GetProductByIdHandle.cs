using Application.Abstractions.Messaging;
using Application.Contracts.Product;
using Domain.Interfaces.Service;
using Mapster;

namespace Application.Queries.GetProductById
{
    public class GetProductByIdHandle : IQueryHandler<GetProductByIdQuery, ProductDto?>
    {
        private readonly IProductService _service;

        public GetProductByIdHandle(IProductService service)
        {
            _service = service;
        }

        public async Task<ProductDto?> Handle(GetProductByIdQuery request, CancellationToken cancellationToken)
        {
            var result = await _service.GetByIdAsync(request.id);

            if (result == null)
                return null;

            var mapped = result.Adapt<ProductDto>();

            return mapped;
        }
    }
}
