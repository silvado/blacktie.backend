using Application.Abstractions.Messaging;

namespace Application.Queries.GetAllUnavailableDate
{
    public sealed record GetAllUnavailableDateQuery(GetAllUnavailableDateParameters parameters) : IQuery<List<DateTime>?>;
}
