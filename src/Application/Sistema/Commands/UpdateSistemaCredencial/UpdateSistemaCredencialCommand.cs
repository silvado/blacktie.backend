using Application.Abstractions.Messaging;
using Application.Contracts;
using Application.Contracts.Sistema;

namespace Application.Commands.UpdateSistemaCredencial
{
    public sealed record UpdateSistemaCredencialCommand(SistemaRequest item) : ICommand<SistemaCadastroDto>;
}
