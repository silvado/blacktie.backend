using Application.Abstractions.Messaging;

namespace Application.Commands.DeleteAddress
{
    public sealed record DeleteAddressCommand(int id) : ICommand<bool>;
}
