using Domain.Entities.Abstracts;

namespace Domain.Models
{
    public class ProductPricing : EntityInt
    {
        public Guid ProductId { get; set; }        
        public int DiscountPercent { get; set; }
        public bool Available { get; set; }
        public int PaymentTypeId { get; set; }
        public virtual PaymentType PaymentType { get; set; }
        public virtual Product Product { get; set; }
    }
}
