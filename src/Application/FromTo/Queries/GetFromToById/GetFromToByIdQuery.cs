using Application.Abstractions.Messaging;
using Application.Contracts.FromTo;

namespace Application.Queries.GetFromToById
{
    public sealed record GetFromToByIdQuery(int id) : IQuery<FromToDto?>;
}
