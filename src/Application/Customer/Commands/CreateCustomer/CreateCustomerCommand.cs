using Application.Abstractions.Messaging;
using Application.Contracts.Customer;

namespace Application.Commands.CreateCustomer
{
    public sealed record CreateCustomerCommand(CustomerDto item) : ICommand<CustomerDto>;
}
