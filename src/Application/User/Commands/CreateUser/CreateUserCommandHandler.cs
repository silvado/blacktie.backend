using Application.Abstractions.Messaging;
using Domain.Interfaces.Service;
using Domain.Models;
using Mapster;

namespace Application.Commands.CreateUser
{
    public class CreateUserCommandHandler : ICommandHandler<CreateUserCommand, bool>
    {
        private readonly IUserService _service;


        public CreateUserCommandHandler(IUserService service)
        {
            _service = service;
        }

        public async Task<bool> Handle(CreateUserCommand request, CancellationToken cancellationToken)
        {

            var r = request.item.Adapt<User>();

            return (await _service.CreateUserAsync(r));

        }
    }
}
