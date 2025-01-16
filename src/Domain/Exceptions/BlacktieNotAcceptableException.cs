using System.Diagnostics.CodeAnalysis;

namespace Domain.Exceptions
{
    [ExcludeFromCodeCoverage]
    public sealed class BlacktieNotAcceptableException : NotAcceptableException
    {
        public BlacktieNotAcceptableException(string message)
            : base(message)
        { }
    }
}
