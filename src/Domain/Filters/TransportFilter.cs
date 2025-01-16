using Domain.Helpers;

namespace Domain.Filters
{
    public sealed record TransportFilter : BaseParameters
    {
        public string? Name { get; set; }
        public int? TotalSmallBags { get; set; }
        public int? TotalBigBags { get; set; }
        public int? TotalPassengers { get; set; }
    }
}
