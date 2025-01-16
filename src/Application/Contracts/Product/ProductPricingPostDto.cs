namespace Application.Contracts.Product
{
    public class ProductPricingPostDto
    {       
        public Guid ProductId { get; set; }        
        public int DiscountPercent { get; set; }
        public bool Available { get; set; }
        public int PaymentTypeId { get; set; }
    }
}
