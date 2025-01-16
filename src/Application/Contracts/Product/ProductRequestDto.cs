namespace Application.Contracts.Product
{
    public class ProductRequestDto
    {
        public Guid Id { get; set; }
        public float Price { get; set; }
        public int FromId { get; set; }
        public int ToId { get; set; }
        public Guid TransportId { get; set; }
        public bool IsLocked { get; set; }
        public string? Comments { get; set; }
    }
}
