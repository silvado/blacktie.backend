using System.Diagnostics.CodeAnalysis;

namespace Domain.Exceptions
{
    [ExcludeFromCodeCoverage]
    public sealed class NoRegisterFoundException : NotFoundException
    {
        public NoRegisterFoundException()
            : base($"Nenhum registro encontrato.")
        {
        }
    }
}


