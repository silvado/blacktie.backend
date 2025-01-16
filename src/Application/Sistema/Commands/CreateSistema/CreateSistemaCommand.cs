using Application.Abstractions.Messaging;
using Application.Contracts;
using Application.Contracts.Sistema;

namespace Application.Commands.CreateSistema
{
    public sealed record CreateSistemaCommand(SistemaRequest item) : ICommand<SistemaCadastroDto>;
}
