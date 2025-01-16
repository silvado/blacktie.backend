using System.Diagnostics.CodeAnalysis;

namespace Domain.Entities.Authentication.Common
{
    [ExcludeFromCodeCoverage]
    public partial class Enumerators
    {
        public enum TipoAmbiente
        {
            Desenvolvimento = 1,
            Homologação = 2,
            Produção = 3,

        }
    }
}
