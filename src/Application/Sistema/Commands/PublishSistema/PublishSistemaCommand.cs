using Application.Abstractions.Messaging;
using Application.Contracts;

namespace Application.Commands.PublishSistema
{ 

    public sealed record PublishSistemaCommand(SistemaRequest item) : ICommand<bool>;
}
