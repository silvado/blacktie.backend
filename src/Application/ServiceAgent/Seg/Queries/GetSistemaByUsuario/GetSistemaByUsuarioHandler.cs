using Application.Abstractions.Messaging;
using Application.Contracts.Seg;
using Domain.Interfaces.Helpers;
using Domain.Interfaces.ServiceAgent;
using Mapster;

namespace Application.ServiceAgent.Seg.Queries.GetSistemaByUsuario
{
    public class GetSistemaByUsuarioHandler : IQueryHandler<GetSistemaByUsuarioQuery, List<SistemaSegDto>?>
    {
        public readonly ISegServiceAgent _service;
        public readonly IUserClaimsHelper _userClaim;


        public GetSistemaByUsuarioHandler(ISegServiceAgent service, IUserClaimsHelper userClaim)
        {
            _service = service;
            _userClaim = userClaim;
        }

        public async Task<List<SistemaSegDto>?> Handle(GetSistemaByUsuarioQuery request, CancellationToken cancellationToken)
        {   

            var result = await _service.GetSistemaByUsuario(_userClaim.GetUserCodUsu()!);


            if (result is null)
                return null;

            var lista = result.Data!.Sistemas;

            return lista!.Adapt<List<SistemaSegDto>>();
        }
    }
}
