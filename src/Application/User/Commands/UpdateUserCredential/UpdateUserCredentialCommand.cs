using Application.Abstractions.Messaging;
using Application.Contracts.User;

namespace Application.Commands.UpdateUserCredential
{    
    public sealed record UpdateUserCredentialCommand(UserDto item) : ICommand<bool>;
}
