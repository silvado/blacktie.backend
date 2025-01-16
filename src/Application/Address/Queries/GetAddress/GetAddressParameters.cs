using Domain.Helpers;

namespace Application.Queries.GetAddress
{    
    public sealed record GetAddressParameters : BaseParameters 
    {
        public Guid? CustomerId { get; set; }
    }
}
