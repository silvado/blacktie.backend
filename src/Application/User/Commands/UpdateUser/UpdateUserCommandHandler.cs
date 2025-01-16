using Application.Abstractions.Messaging;
using Domain.Interfaces.Service;
using Mapster;
using Domain.Models;

namespace Application.Commands.UpdateUser
{
    public class UpdateUserCommandHandler : ICommandHandler<UpdateUserCommand, bool>
    {
        private readonly IUserService _service;


        public UpdateUserCommandHandler(IUserService service)
        {
            _service = service;
        }

        public async Task<bool> Handle(UpdateUserCommand request, CancellationToken cancellationToken)
        {

            var r = request.item.Adapt<User>();

            return (await _service.UpdateUserAsync(r));

        }
    }
}
