using Domain.Entities.Abstracts;

namespace Domain.Models
{
    public class Product: EntityGuid
    {   
        public float Price { get; set; }
        public int FromId { get; set; }
        public int ToId { get; set; }
        public Guid TransportId { get; set; }
        public bool IsLocked { get; set; }
        public string? Comments { get; set; }
        public virtual Transport Transport { get; set; }
        public virtual FromTo From { get; set; }
        public virtual FromTo To { get; set; }
        public ICollection<ProductPricing>? Pricing { get; set; }
    }
}
