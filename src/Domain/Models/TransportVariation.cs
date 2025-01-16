using Domain.Entities.Abstracts;

namespace Domain.Models
{
    public class TransportVariation : EntityInt
    {
        public Guid TransportId { get; set; } 
        public int TotalSmallBags { get; set; }
        public int TotalBigBags { get; set; }
        public int TotalPassengers { get; set; }
        public virtual Transport Transport { get; set; } 
    }
}
