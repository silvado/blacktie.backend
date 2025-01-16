using Application.Contracts.Customer;
using Application.Contracts.PaymentType;
using Application.Contracts.Product;
using Domain.Enums;

namespace Application.Contracts.Order
{
    public class OrderDto
    {
        public Guid Id { get; set; }
        public Guid ProductId { get; set; }
        public Guid CustomerId { get; set; }
        public DateTime Date { get; set; }
        public int TotalSmallBags { get; set; }
        public int TotalBigBags { get; set; }
        public int TotalPassengers { get; set; }
        public int Amount { get; set; }
        public float Price { get; set; }
        public EPaymentStatus? PaymentStatus { get; set; }
        public ProductDto? Product { get; set; }
        public CustomerDto? Customer { get; set; }
        public PaymentTypeDto? PaymentType { get; set; }
    }
}
