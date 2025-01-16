using Domain.Entities.Authentication.Common;

namespace Domain.Models
{
    [Serializable]
    public class UserSegWeb
    {
        public string? CodUsu { get; set; } = string.Empty;

        public string? UsuarioSO { get; set; }

        public string? NomeMaquina { get; set; }

        public string? SiglaSist { get; set; } = "SIGLA";

        public int? CodOrg { get; set; }

        public int? CodOrgaoLotado { get; set; }

        public int? IDPessoa { get; set; }

        public int? IDFunc { get; set; }

        public int? IDUsu { get; set; }

        public string? Matricula { get; set; }

        public string? Nome { get; set; } = string.Empty;

        public string? OrgaoLotacao { get; set; }

        public IList<EstruturaAutorizacao>? Autorizacoes { get; set; }

        public string? Token { get; set; }
    }

}
