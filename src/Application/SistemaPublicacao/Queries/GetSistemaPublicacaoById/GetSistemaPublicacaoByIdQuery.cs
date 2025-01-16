using Application.Abstractions.Messaging;
using Application.Contracts;

namespace Application.Queries.GetSistemaPublicacaoById
{
    public sealed record GetSistemaPublicacaoByIdQuery(int id) : IQuery<SistemaPublicacaoDto?>;
}
