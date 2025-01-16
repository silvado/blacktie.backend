using Application.Abstractions.Messaging;
using Application.Contracts.UnavailableDate;

namespace Application.Commands.CreateUnavailableDate
{
    public sealed record CreateUnavailableDateCommand(UnavailableDateDto item) : ICommand<UnavailableDateDto>;
}
