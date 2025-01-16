namespace Application.Contracts.Order
{
    public class OrderPostDto
    {
        public Guid ProductId { get; set; }
        public Guid CustomerId { get; set; }
        public DateTime Date { get; set; }
        public int TotalSmallBags { get; set; }
        public int TotalBigBags { get; set; }
        public int TotalPassengers { get; set; }
        public int Amount { get; set; }
        public float Price { get; set; }
        public Guid UserId { get; set; }
    }
}
