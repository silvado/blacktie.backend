using System.Diagnostics.CodeAnalysis;

namespace Domain.Exceptions
{
    [ExcludeFromCodeCoverage]
    public sealed class ModeloNotFoundException : NotFoundException
    {
        public ModeloNotFoundException()
            : base($"Modelo inexistente.")
        { }
    }
}
