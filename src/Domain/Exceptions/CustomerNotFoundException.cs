using System.Diagnostics.CodeAnalysis;

namespace Domain.Exceptions
{
    [ExcludeFromCodeCoverage]
    public sealed class CustomerNotFoundException : NotFoundException
    {
        public CustomerNotFoundException()
            : base($"Cliente inexistente.")
        { }
    }
}
