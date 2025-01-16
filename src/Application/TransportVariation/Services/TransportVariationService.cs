using Domain.Interfaces.Repository;
using Domain.Interfaces.Service;
using Domain.Models;

namespace Application.Services
{
    public class TransportVariationService : ITransportVariationService
    {
        private readonly ITransportVariationRepository _repository;


        public TransportVariationService(ITransportVariationRepository repository)
        {
            _repository = repository;
        }


        public async Task<bool> CreateAsync(TransportVariation transport)
        {


            var newTransport = await _repository.AddAndSaveAsync(transport);

            return true;
        }

        public async Task<bool> UpdateAsync(TransportVariation transport)
        {

            await _repository.UpdateAsync(transport);

            return true;
        }

        public async Task<bool> DeleteAsync(int id)
        {

            await _repository.SoftDeleteAsync(id);

            return true;
        }

        public async Task<TransportVariation?> GetByIdAsync(int id)
        {

            var result = await _repository.GetByIdAsync(id);

            if (result == null)
                return null;


            return result;
        }
    }
}
