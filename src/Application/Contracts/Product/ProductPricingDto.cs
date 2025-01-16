using Application.Contracts.PaymentType;
using Domain.Models;

namespace Application.Contracts.Product
{
    public class ProductPricingDto
    {
        public int Id { get; set; }
        public Guid ProductId { get; set; }        
        public int DiscountPercent { get; set; }
        public bool Available { get; set; }        
        public PaymentTypeDto? PaymentType { get; set; }
        public ProductDto? Product { get; set; }
    }
}
