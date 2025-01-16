using Domain.Helpers;

namespace Domain.Filters
{
    public sealed record OrderFilter : BaseParameters
    {
        public Guid? CustomerId { get; set; }
        public Guid? ProductId { get; set; }
    }
}
