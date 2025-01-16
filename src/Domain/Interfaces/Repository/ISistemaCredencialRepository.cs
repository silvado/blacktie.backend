using Domain.Interfaces.Common;
using Domain.Models;

namespace Domain.Interfaces.Repository
{
    public interface ISistemaCredencialRepository : IGenericAsyncRepository<SistemaCredencial>
    {
        Task<List<SistemaCredencial>?> GetByIdSistemaAsync(int sistemaId);
    }
}
