namespace Application.Contracts.Sistema
{
    public class SistemaCadastroDto
    {
        public int Id { get; set; }
        public string? NomeSistema { get; set; }
        public string? SiglaSistema { get; set; }
        public string? Username { get; set; }
        public string? Password { get; set; }
        public DateTime? CreatedAt { get; set; }
        public string? CreatedByUserId { get; set; }
    }
}
