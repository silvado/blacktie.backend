using Domain.Interfaces.ServiceAgent.DataContracts.Response;

namespace Domain.Interfaces.ServiceAgent
{
    public interface ISegServiceAgent
    {
        Task<OperationResponse<SegResponse>?> GetSistemaByUsuario(string codUsu);
    }
}
