using Application.Abstractions.Messaging;
using Application.Contracts.Product;

namespace Application.Queries.GetProductById
{
    public sealed record GetProductByIdQuery(Guid id) : IQuery<ProductDto?>;
}
