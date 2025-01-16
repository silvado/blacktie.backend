using Domain.Helpers;

namespace Application.Queries.GetUnavailableDate
{
    public sealed record GetUnavailableDateParameters : BaseParameters
    {
        public int? Year { get; set; }
    }
}
