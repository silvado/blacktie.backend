using System.Diagnostics.CodeAnalysis;

namespace Domain.Exceptions
{
    [ExcludeFromCodeCoverage]
    public abstract class NotFoundException : System.ApplicationException
    {
        protected NotFoundException(string message)
            : base("Not Found", new Exception(message))
        {
        }
    }
}