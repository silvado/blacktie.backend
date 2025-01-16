using Application.Abstractions.Messaging;
using Application.Contracts.Product;
using Domain.Filters;
using Domain.Helpers;
using Domain.Interfaces.Service;
using Mapster;

namespace Application.Queries.GetProduct
{
    public class GetProductHandler : IQueryHandler<GetProductQuery, PagedList<ProductDto>?>
    {
        private readonly IProductService _service;

        public GetProductHandler(IProductService service)
        {
            _service = service;
        }

        public async Task<PagedList<ProductDto>?> Handle(GetProductQuery request, CancellationToken cancellationToken)
        {
            var filter = request.parameters.Adapt<ProductFilter>();

            filter.IsDeleted = false;

            var result = await _service.GetFilteredAsync(filter);

            if (result == null)
                return null;

            var mapped = result.Data.Adapt<List<ProductDto>>();
            return new PagedList<ProductDto>(mapped, result.TotalCount, request.parameters.PageNumber, request.parameters.PageSize);
        }
    }
}
