using Domain.Helpers;

namespace Application.Queries.GetAllUnavailableDate
{
    public sealed record GetAllUnavailableDateParameters : BaseParameters
    {
        public int? Year { get; set; }
    }
}
