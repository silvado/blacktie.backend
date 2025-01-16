namespace Domain.Filters
{
    public class SistemaFilter
    {
        
        public string? NomeSistema { get; set; }
        public string? SiglaSistema { get; set; }
        public int PageNumber { get; set; } = 1;
        public int PageSize { get; set; } = 10;
        public int TotalCount { get; set; } = 10;
    }
}
