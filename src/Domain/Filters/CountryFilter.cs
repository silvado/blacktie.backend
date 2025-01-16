using Domain.Helpers;

namespace Domain.Filters
{
    public sealed record CountryFilter : BaseParameters
    {
        public string? Name { get; set; }
    }
}
