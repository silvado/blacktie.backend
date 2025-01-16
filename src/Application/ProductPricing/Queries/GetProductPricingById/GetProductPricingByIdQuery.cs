using Application.Abstractions.Messaging;
using Application.Contracts.Product;

namespace Application.Queries.GetProductPricingById
{
    public sealed record GetProductPricingByIdQuery(int id) : IQuery<ProductPricingDto?>;
}
