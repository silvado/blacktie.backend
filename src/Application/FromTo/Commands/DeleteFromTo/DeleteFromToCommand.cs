using Application.Abstractions.Messaging;

namespace Application.Commands.DeleteFromTo
{
    public sealed record DeleteFromToCommand(int id) : ICommand<bool>;
}
