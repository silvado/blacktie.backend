using Application.Abstractions.Messaging;

namespace Application.Commands.DeleteCustomer
{
    public sealed record DeleteCustomerCommand(Guid Id) : ICommand<bool>;
}
