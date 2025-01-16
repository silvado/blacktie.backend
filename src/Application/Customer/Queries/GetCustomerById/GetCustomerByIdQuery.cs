using Application.Abstractions.Messaging;
using Application.Contracts.Customer;

namespace Application.Queries.GetCustomerById
{
    public sealed record GetCustomerByIdQuery(Guid id) : IQuery<CustomerDto?>;
}
