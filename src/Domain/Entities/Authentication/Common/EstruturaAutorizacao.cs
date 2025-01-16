using System.Diagnostics.CodeAnalysis;

namespace Domain.Entities.Authentication.Common
{
    [Serializable]
    [ExcludeFromCodeCoverage]
    public class EstruturaAutorizacao
    {
        public string? Janela { get; set; }
        public string? UrlCertDig { get; set; }
        public string? ObjFunc { get; set; }
        public string? SiglaFunc { get; set; }
        public string? IndAutorizado { get; set; }
        public string? IndAutorizadoCertDig { get; set; }
    }

}
