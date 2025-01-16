using Application.Abstractions.Messaging;
using Application.Contracts.Seg;

namespace Application.ServiceAgent.Seg.Queries.GetSistemaByUsuario
{

    public sealed record GetSistemaByUsuarioQuery() : IQuery<List<SistemaSegDto>?>;
}
