namespace Application.Contracts.Transport
{
    public class TransportVariationDto
    {
        public int Id { get; set; }
        public Guid TransportId { get; set; }
        public int TotalSmallBags { get; set; }
        public int TotalBigBags { get; set; }
        public int TotalPassengers { get; set; }
    }

}
