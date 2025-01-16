using Application.Abstractions.Messaging;
using Domain.Interfaces.Service;
using Domain.Models;
using Mapster;

namespace Application.Commands.UpdateUserCredential
{
    public class UpdateUserCredentialCommandHandler : ICommandHandler<UpdateUserCredentialCommand, bool>
    {
        private readonly IUserService _service;


        public UpdateUserCredentialCommandHandler(IUserService service)
        {
            _service = service;
        }

        public async Task<bool> Handle(UpdateUserCredentialCommand request, CancellationToken cancellationToken)
        {

            var r = request.item.Adapt<User>();

            return (await _service.UpdateUserCredentialAsync(r));

        }
    }
}
