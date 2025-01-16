using Application.Abstractions.Messaging;
using Application.Contracts;

namespace Application.Queries.GetSistemaById
{
    public sealed record GetSistemaByIdQuery(int id) : IQuery<SistemaDto?>;
}
