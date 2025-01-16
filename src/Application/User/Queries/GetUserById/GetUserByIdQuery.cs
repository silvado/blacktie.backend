using Application.Abstractions.Messaging;
using Application.Contracts.User;

namespace Application.Queries.GetUserById
{
    public sealed record GetUserByIdQuery(Guid id) : IQuery<UserDto?>;
}
