using Application.Abstractions.Messaging;
using Application.Contracts.User;
using Domain.Helpers;

namespace Application.Queries.GetUser
{
    public sealed record GetUserQuery(GetUserParameters parameters) : IQuery<PagedList<UserDto>?>;
}
