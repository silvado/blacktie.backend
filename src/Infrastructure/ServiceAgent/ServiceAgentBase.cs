using Domain.Interfaces.ServiceAgent.DataContracts.Response;
using Infrastructure.ServiceAgent.Enum;

namespace Infrastructure.ServiceAgent
{
    public abstract class ServiceAgentBase
    {
        protected abstract Uri BaseAddress { get; }
        private readonly HttpAgentBase _agent;

        protected ServiceAgentBase(HttpAgentBase agent)
        {
            _agent = agent;
        }

        public Task<OperationResponse<T>>? Requisitar<T>(string url)
        {
            _agent.ConfigureBaseAddress(BaseAddress);
            return _agent.Requisitar<T>(url);
        }


        public Task<OperationResponse<TResponse>>? Incluir<TRequest, TResponse>(string url, TRequest obj)
        {
            _agent.ConfigureBaseAddress(BaseAddress);
            return _agent.Incluir<TRequest, TResponse>(url, obj);
        }

        public Task<OperationResponse<TResponse>> Alterar<TRequest, TResponse>(string url, TRequest obj)
        {
            _agent.ConfigureBaseAddress(BaseAddress);
            return _agent.Alterar<TRequest, TResponse>(url, obj);
        }

        public Task<OperationResponse<T>> Excluir<T>(string url)
        {
            _agent.ConfigureBaseAddress(BaseAddress);
            return _agent.Excluir<T>(url);
        }
        public Task<OperationResponse<T>>? Persistir<T>(string url, object data, VerboHttp? verbo = VerboHttp.PUT, string token = "")
        {
            return _agent.Persistir<T>(url, BaseAddress, data, verbo, token);
        }
        public Task<OperationResponse<T>>? Obter<T>(string url, string token = "", AuthType? authType = AuthType.BEARER)
        {
            return _agent.Obter<T>(url, BaseAddress, token, authType);
        }      

    }
}
