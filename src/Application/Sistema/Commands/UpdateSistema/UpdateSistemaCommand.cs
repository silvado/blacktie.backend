using Application.Abstractions.Messaging;
using Application.Contracts;

namespace Application.Commands.UpdateSistema
{
    public sealed record UpdateSistemaCommand(SistemaRequest item) : ICommand<bool>;
}
