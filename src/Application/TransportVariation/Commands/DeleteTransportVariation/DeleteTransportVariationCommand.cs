using Application.Abstractions.Messaging;

namespace Application.Commands.DeleteTransportVariation
{
    public sealed record DeleteTransportVariationCommand(int id) : ICommand<bool>;
}
