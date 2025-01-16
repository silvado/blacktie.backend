using Domain.Helpers;

namespace Domain.Filters
{
    public sealed record GenericFilter : BaseParameters
    {
        public string? Name { get; set; }
    }
}
