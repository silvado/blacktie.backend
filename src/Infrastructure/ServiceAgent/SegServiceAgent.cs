using Domain.Interfaces.ServiceAgent;
using Domain.Interfaces.ServiceAgent.DataContracts.Response;
using Microsoft.Extensions.Configuration;

namespace Infrastructure.ServiceAgent
{
    public class SegServiceAgent : ServiceAgentBase, ISegServiceAgent
    {
        private readonly IConfiguration _configuration;
        public SegServiceAgent(IConfiguration configuration, HttpAgentBase agent) : base(agent)
        {
            _configuration = configuration;
        }
        protected override Uri BaseAddress => new Uri(_configuration["SegRest:BaseUrl"]!);

        public async Task<OperationResponse<SegResponse>?> GetSistemaByUsuario(string codUsu)
        {

            return await this.Obter<SegResponse>($"sistemas/?codUsu={codUsu}", string.Empty, null)!;

        }


    }
}
