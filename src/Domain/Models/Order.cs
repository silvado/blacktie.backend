using Domain.Entities.Abstracts;
using Domain.Enums;

namespace Domain.Models
{
    public class Order : EntityGuid
    {
        public Guid ProductId { get; set; }
        public Guid CustomerId { get; set; }
        public DateTime Date { get; set; }
        public int TotalSmallBags { get; set; }
        public int TotalBigBags { get; set; }
        public int TotalPassengers { get; set; }
        public int Amount { get; set; }
        public float Price { get; set; }
        public int? PaymentTypeId { get; set; }
        public EPaymentStatus? PaymentStatus { get; set; }
        public DateTime? ExpireAt { get; set; }
        public virtual Product Product { get; set; }
        public virtual Customer Customer { get; set; }
        public virtual PaymentType PaymentType { get; set; }
    }
}
