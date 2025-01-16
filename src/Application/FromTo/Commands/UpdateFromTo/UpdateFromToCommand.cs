using Application.Abstractions.Messaging;
using Application.Contracts.FromTo;

namespace Application.Commands.UpdateFromTo
{
    public sealed record UpdateFromToCommand(FromToDto item) : ICommand<bool>;
}
