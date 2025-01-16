using Application.Abstractions.Messaging;
using Application.Contracts.Customer;
using Domain.Helpers;

namespace Application.Queries.GetCustomer
{
    public sealed record GetCustomerQuery(GetCustomerParameters parameters) : IQuery<PagedList<CustomerDto>?>;
}
