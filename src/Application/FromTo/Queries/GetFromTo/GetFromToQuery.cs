using Application.Abstractions.Messaging;
using Application.Contracts.FromTo;
using Domain.Helpers;

namespace Application.Queries.GetFromTo
{
    public sealed record GetFromToQuery(GetFromToParameters parameters) : IQuery<PagedList<FromToDto>?>;
}
