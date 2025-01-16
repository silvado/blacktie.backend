using Application.Abstractions.Messaging;
using Application.Contracts.User;

namespace Application.Commands.CreateUser
{
    public sealed record CreateUserCommand(UserDto item) : ICommand<bool>;
}
