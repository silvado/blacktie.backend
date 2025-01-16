using System.Diagnostics.CodeAnalysis;

namespace Domain.Exceptions
{
    [ExcludeFromCodeCoverage]
    public sealed class ModeloException : Exception
    {
        public ModeloException(string message) : base(message) { }
}
}
