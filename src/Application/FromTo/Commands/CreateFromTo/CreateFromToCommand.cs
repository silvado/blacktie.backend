using Application.Abstractions.Messaging;
using Application.Contracts.FromTo;

namespace Application.Commands.CreateFromTo
{
    public sealed record CreateFromToCommand(FromToDto item) : ICommand<FromToDto>;
}
