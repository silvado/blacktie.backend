namespace Application.Contracts.UnavailableDate
{
    public class UnavailableDateDto
    {
        public int Id { get; set; }
        public int Year { get; set; }
        public DateTime StartAt { get; set; }
        public DateTime? EndAt { get; set; }
        public string? Obs { get; set; }
    }
}
