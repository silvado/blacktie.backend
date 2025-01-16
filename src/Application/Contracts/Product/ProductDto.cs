using Application.Contracts.FromTo;
using Application.Contracts.Transport;

namespace Application.Contracts.Product
{
    public class ProductDto
    {
        public Guid Id { get; set; }
        public float Price { get; set; }
        public bool IsLocked { get; set; }
        public string? Comments { get; set; }
        public TransportDto? Transport { get; set; }
        public FromToDto? From { get; set; }
        public FromToDto? To { get; set; }
        public ICollection<ProductPricingDto>? Pricing { get; set; }
    }
}
