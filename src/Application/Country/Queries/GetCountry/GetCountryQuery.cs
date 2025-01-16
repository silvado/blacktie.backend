using Application.Abstractions.Messaging;
using Application.Contracts.Country;
using Domain.Helpers;

namespace Application.Queries.GetCountry
{
    public sealed record GetCountryQuery(GetCountryParameters parameters) : IQuery<PagedList<CountryDto>?>;
}
