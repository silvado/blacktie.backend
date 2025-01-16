using Application.Abstractions.Messaging;
using Application.Contracts.User;

namespace Application.Commands.UpdateUser
{
    public sealed record UpdateUserCommand(UserDto item) : ICommand<bool>;
}
