using Application.Abstractions.Messaging;
using Application.Contracts.PaymentType;
using Domain.Helpers;

namespace Application.Queries.GetPaymentType
{
    public sealed record GetPaymentTypeQuery(GetPaymentTypeParameters parameters) : IQuery<PagedList<PaymentTypeDto>?>;
}
