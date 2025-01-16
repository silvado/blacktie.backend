using Domain.Helpers;

namespace Application.Queries.GetSistemaPublicacao
{
    public sealed record GetSistemaPublicacaoParameters : BaseParameters 
    {
        public int? IdSistema { get; set; }
    }
}
