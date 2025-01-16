using Application.Abstractions.Messaging;

namespace Application.Commands.DeleteUnavailableDate
{
    public sealed record DeleteUnavailableDateCommand(int id) : ICommand<bool>;
}
