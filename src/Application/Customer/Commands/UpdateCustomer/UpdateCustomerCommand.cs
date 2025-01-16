using Application.Abstractions.Messaging;
using Application.Contracts.Customer;
using Domain.Helpers;
using Domain.Models;

namespace Application.Commands.UpdateCustomer
{   
    public sealed record UpdateCustomerCommand(UpdateCustomerDto item) : ICommand<ResultWrapper<Customer>>;
}
