using Domain.Helpers;

namespace Domain.Filters
{
    public sealed record CustomerFilter : BaseParameters
    {
        public string? Name { get; set; }
        public string? Email { get; set; }
    }
}
