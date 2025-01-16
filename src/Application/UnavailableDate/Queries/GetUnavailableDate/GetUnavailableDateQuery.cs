using Application.Abstractions.Messaging;
using Application.Contracts.UnavailableDate;
using Application.Queries.GetUnavailableDate;
using Domain.Helpers;

namespace Application.Queries.GetUnavailableDateByYear
{
    public sealed record GetUnavailableDateQuery(GetUnavailableDateParameters parameters) : IQuery<PagedList<UnavailableDateDto>?>;
}
