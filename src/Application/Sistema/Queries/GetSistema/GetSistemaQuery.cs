using Application.Abstractions.Messaging;
using Application.Contracts;
using Domain.Helpers;

namespace Application.Queries.GetSistema
{

    public sealed record GetSistemaQuery(GetSistemaParameters parameters) : IQuery<PagedList<SistemaDto>?>;
}
