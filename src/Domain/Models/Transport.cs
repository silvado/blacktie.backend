using Domain.Entities.Abstracts;

namespace Domain.Models
{
    public class Transport : EntityGuid
    {
        public string? Name { get; set; }
        public string? Brand { get; set; }
        public string? Model { get; set; }
        public string? Image { get; set; }
        public string? YoutubeLink { get; set; }
        public ICollection<TransportVariation>? Variations { get; set; }

    }
}
