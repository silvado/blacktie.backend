using Application.Abstractions.Messaging;
using Application.Contracts;
using Application.Contracts.User;
using Application.Queries.GetUser;
using Domain.Filters;
using Domain.Helpers;
using Domain.Interfaces.Service;
using Mapster;

namespace Application.Queries.GetUser
{
    public class GetUserHandler : IQueryHandler<GetUserQuery, PagedList<UserDto>?>
    {
        private readonly IUserService _service;

        public GetUserHandler(IUserService service)
        {
            _service = service;
        }

        public async Task<PagedList<UserDto>?> Handle(GetUserQuery request, CancellationToken cancellationToken)
        {
            var filter = request.parameters.Adapt<UserFilter>();
            var result = await _service.GetFilteredAsync(filter);

            if (result == null)
                return null;

            var mapped = result.Data.Adapt<List<UserDto>>();
            return new PagedList<UserDto>(mapped, result.TotalCount, request.parameters.PageNumber, request.parameters.PageSize);
        }
    }
}
