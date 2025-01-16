using Application.Abstractions.Messaging;
using Application.Contracts.Product;
using Domain.Interfaces.Service;
using Domain.Models;
using Mapster;

namespace Application.Commands.CreateProduct
{
    public class CreateProductCommandHandler : ICommandHandler<CreateProductCommand, ProductDto>
    {
        private readonly IProductService _service;


        public CreateProductCommandHandler(IProductService service)
        {
            _service = service;
        }

        public async Task<ProductDto> Handle(CreateProductCommand request, CancellationToken cancellationToken)
        {
            var r = request.item.Adapt<Product>();

            var p = await _service.CreateAsync(r);

            return (await _service.GetByIdAsync(p.Id)).Adapt<ProductDto>();
        }
    }
}
