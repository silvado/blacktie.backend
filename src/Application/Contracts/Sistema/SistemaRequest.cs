namespace Application.Contracts
{
    public class SistemaRequest
    {
        public int Id { get; set; }
        public string? NomeSistema { get; set; }
        public string? SiglaSistema { get; set; }
        public string? Configuracao { get; set; }
        public string? ConfiguracaoPrevia { get; set; }
    }
}
