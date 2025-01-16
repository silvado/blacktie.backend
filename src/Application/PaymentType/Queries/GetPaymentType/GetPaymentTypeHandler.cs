using Application.Abstractions.Messaging;
using Application.Contracts.PaymentType;
using Domain.Filters;
using Domain.Helpers;
using Domain.Interfaces.Service;
using Mapster;

namespace Application.Queries.GetPaymentType
{
    public class GetPaymentTypeHandler : IQueryHandler<GetPaymentTypeQuery, PagedList<PaymentTypeDto>?>
    {
        private readonly IPaymentTypeService _service;

        public GetPaymentTypeHandler(IPaymentTypeService service)
        {
            _service = service;
        }

        public async Task<PagedList<PaymentTypeDto>?> Handle(GetPaymentTypeQuery request, CancellationToken cancellationToken)
        {
            var filter = request.parameters.Adapt<GenericFilter>();
            var result = await _service.GetFilteredAsync(filter);

            if (result == null)
                return null;

            var mapped = result.Data.Adapt<List<PaymentTypeDto>>();
            return new PagedList<PaymentTypeDto>(mapped, result.TotalCount, request.parameters.PageNumber, request.parameters.PageSize);
        }
    }
}
