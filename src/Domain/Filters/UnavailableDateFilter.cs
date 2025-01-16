using Domain.Helpers;

namespace Domain.Filters
{
    public sealed record UnavailableDateFilter : BaseParameters
    {
        public int? Year { get; set; }
        public DateTime? StartAt { get; set; }
        public DateTime? EndAt { get; set; }
    }
}
