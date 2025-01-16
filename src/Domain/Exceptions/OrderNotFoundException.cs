using System.Diagnostics.CodeAnalysis;

namespace Domain.Exceptions
{
    [ExcludeFromCodeCoverage]
    public sealed class OrderNotFoundException : NotFoundException
    {
        public OrderNotFoundException()
            : base($"Pedido inexistente.")
        { }
    }
}
