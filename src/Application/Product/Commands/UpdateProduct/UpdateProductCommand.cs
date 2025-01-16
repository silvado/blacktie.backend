using Application.Abstractions.Messaging;
using Application.Contracts.Product;

namespace Application.Commands.UpdateProduct
{
    public sealed record UpdateProductCommand(ProductRequestDto item) : ICommand<bool>;
}
