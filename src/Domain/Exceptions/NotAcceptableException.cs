using System.Diagnostics.CodeAnalysis;

namespace Domain.Exceptions
{
    [ExcludeFromCodeCoverage]
    public abstract class NotAcceptableException : System.ApplicationException
    {
        protected NotAcceptableException(string message)
           : base(message)
        {
        }
    }
}
