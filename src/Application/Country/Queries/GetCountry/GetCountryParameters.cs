using Domain.Helpers;

namespace Application.Queries.GetCountry
{
    public sealed record GetCountryParameters : BaseParameters 
    {
        public string? Name { get; set; }
    }
}
