using Application.Abstractions.Messaging;
using Application.Contracts;
using Application.Contracts.User;
using Application.Queries.GetUserById;
using Domain.Interfaces.Service;
using Mapster;

namespace Application.Queries.GetUserById
{
    public class GetUserByIdHandler : IQueryHandler<GetUserByIdQuery, UserDto?>
    {
        private readonly IUserService _service;

        public GetUserByIdHandler(IUserService service)
        {
            _service = service;
        }

        public async Task<UserDto?> Handle(GetUserByIdQuery request, CancellationToken cancellationToken)
        {
            var result = await _service.GetUserByIdAsync(request.id);

            if (result == null)
                return null;


            var mapped = result.Adapt<UserDto>();
            

            return result.Adapt<UserDto>();
        }
    }
}
