using Domain.Entities.Abstracts;

namespace Domain.Models
{
    public class UnavailableDate : EntityInt
    {
        public int Year { get; set; }
        public DateTime StartAt { get; set; }
        public DateTime? EndAt { get; set; }
        public string? Obs { get; set; }
    }
}
