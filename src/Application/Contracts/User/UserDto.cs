namespace Application.Contracts.User
{
    public sealed record UserDto
    (
        Guid Id,
        string Name,
        string Email,
        string Token
    );
}
