using Domain.Helpers;

namespace Application.Queries.GetTransport
{
    public sealed record GetTransportParameters : BaseParameters 
    {
        public int? TotalSmallBags { get; set; }
        public int? TotalBigBags { get; set; }
        public int? TotalPassengers { get; set; }
    }
}
