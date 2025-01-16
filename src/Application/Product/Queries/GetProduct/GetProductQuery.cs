using Application.Abstractions.Messaging;
using Application.Contracts.Product;
using Domain.Helpers;

namespace Application.Queries.GetProduct
{
    public sealed record GetProductQuery(GetProductParameters parameters) : IQuery<PagedList<ProductDto>?>;
}
