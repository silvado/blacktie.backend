using Newtonsoft.Json;
using System.Diagnostics.CodeAnalysis;

namespace Domain.Entities.Authentication.Common
{
    [ExcludeFromCodeCoverage]
    public class SegWebCredential
    {
        [JsonProperty("SIGLASISTEMA")]
        public string SiglaSistema { get; set; } = "SAPICONFIG";

        [JsonProperty("CHAVE")]
        public string SessionId { get; set; }

        [JsonProperty("CODORGAO")]
        public string CodOrgao { get; set; }

        public SegWebCredential(string _sessionId, string _codigoOrganizacao)
        {
            SessionId = _sessionId;
            CodOrgao = _codigoOrganizacao;
        }
    }
}
