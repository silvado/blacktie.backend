using Application.Abstractions.Messaging;
using Application.Contracts.Product;

namespace Application.Commands.CreateProduct
{
    public sealed record CreateProductCommand(ProductRequestDto item) : ICommand<ProductDto>;
}
