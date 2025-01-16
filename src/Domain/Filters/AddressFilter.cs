using Domain.Helpers;

namespace Domain.Filters
{
    public sealed record AddressFilter : BaseParameters
    {
        public string?  Street { get; set; }
    }
}
