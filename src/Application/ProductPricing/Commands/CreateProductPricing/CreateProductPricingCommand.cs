using Application.Abstractions.Messaging;
using Application.Contracts.Product;

namespace Application.Commands.CreateProductPricing
{
    public sealed record CreateProductPricingCommand(ProductPricingPostDto item) : ICommand<ProductPricingDto>;
}
