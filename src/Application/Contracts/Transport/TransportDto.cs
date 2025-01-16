using Domain.Models;

namespace Application.Contracts.Transport
{
    public class TransportDto
    {
        public Guid Id { get; set; }
        public string? Name { get; set; }
        public string? Brand { get; set; }
        public string? Model { get; set; }
        public string? Image { get; set; }
        public string? YoutubeLink { get; set; }
        public ICollection<TransportVariationDto>? Variations { get; set; }
    }
}
