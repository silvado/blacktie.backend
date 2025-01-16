using Application.Abstractions.Messaging;
using Application.Contracts.UnavailableDate;

namespace Application.Commands.UpdateUnavailableDate
{
    public sealed record UpdateUnavailableDateCommand(UnavailableDateDto item) : ICommand<bool>;
}
