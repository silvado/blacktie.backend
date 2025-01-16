using Application.Abstractions.Messaging;

namespace Application.Commands.DeleteSistema
{
    public sealed record DeleteSistemaCommand(int id) : ICommand<bool>;
}
