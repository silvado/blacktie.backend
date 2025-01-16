using System.Diagnostics.CodeAnalysis;

namespace Domain.Exceptions
{
    [ExcludeFromCodeCoverage]
    public abstract class BadRequestException : System.ApplicationException
    {
        protected BadRequestException(string message)
            : base("Bad Request", new Exception(message))
        {
        }
    }
}