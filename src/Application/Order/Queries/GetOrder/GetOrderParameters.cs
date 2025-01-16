using Domain.Helpers;

namespace Application.Queries.GetOrder
{
    public sealed record GetOrderParameters : BaseParameters
    {       
        public Guid? ProductId { get; set; }
        public Guid? CustomerId { get; set; }
     
    }
}
