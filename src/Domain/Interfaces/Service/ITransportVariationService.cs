using Domain.Models;

namespace Domain.Interfaces.Service
{
    public interface ITransportVariationService
    {
        Task<bool> CreateAsync(TransportVariation transport);
        Task<bool> UpdateAsync(TransportVariation transport);
        Task<bool> DeleteAsync(int id);
        Task<TransportVariation?> GetByIdAsync(int id);

    }
}
