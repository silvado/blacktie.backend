namespace Domain.Filters
{
    public class SistemaPublicacaoFilter
    {
        
        public string? NomeSistema { get; set; } = null;
        public int? IdSistema { get; set; } = null;

        public int PageNumber { get; set; } = 1;
        public int PageSize { get; set; } = 10;
        public int TotalCount { get; set; } = 10;
    }
}
