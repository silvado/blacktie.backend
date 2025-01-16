using Application.Abstractions.Messaging;

namespace Application.Commands.DeleteProduct
{
    public sealed record DeleteProductCommand(Guid id) : ICommand<bool>;
}
