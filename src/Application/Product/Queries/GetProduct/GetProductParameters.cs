using Domain.Helpers;

namespace Application.Queries.GetProduct
{
    public sealed record GetProductParameters : BaseParameters
    {
        public int? FromId { get; set; }
        public int? ToId { get; set; }
        public Guid? TransportId { get; set; }
        public int? TotalSmallBags { get; set; }
        public int? TotalBigBags { get; set; }
        public int? TotalPassengers { get; set; }
        public bool? IsLocked { get; set; }
    }
}
