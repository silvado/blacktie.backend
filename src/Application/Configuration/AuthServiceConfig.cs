using System.Diagnostics.CodeAnalysis;

namespace Application.Configuration
{
    [ExcludeFromCodeCoverage]
    public class AuthServiceConfig
    {
        public string? SecretKey { get; set; }
        public string? UrlPermissao { get; set; }
        public int TokenExpMinutes { get; set; }
    }
}
