using Application.Abstractions.Messaging;

namespace Application.Commands.DeleteProductPricing
{
    public sealed record DeleteProductPricingCommand(int id) : ICommand<bool>;
}
