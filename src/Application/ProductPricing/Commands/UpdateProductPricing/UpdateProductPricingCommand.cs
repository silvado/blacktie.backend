using Application.Abstractions.Messaging;
using Application.Contracts.Product;

namespace Application.Commands.UpdateProductPricing
{
    public sealed record UpdateProductPricingCommand(ProductPricingPostDto item) : ICommand<bool>;
}
