using Application.Abstractions.Messaging;
using Application.Contracts;
using Domain.Helpers;

namespace Application.Queries.GetSistemaPublicacao
{

    public sealed record GetSistemaPublicacaoQuery(GetSistemaPublicacaoParameters parameters) : IQuery<PagedList<SistemaPublicacaoDto>?>;
}
