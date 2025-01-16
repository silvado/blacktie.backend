using Domain.Entities.Abstracts;
using Domain.Enums;

namespace Domain.Models
{
    public class Administrador : EntityInt
    {
        public string? CodigoUsuario { get; set; }
        public ETipoAdministrador? TipoAdministrador { get; set; }

       
    }
}
