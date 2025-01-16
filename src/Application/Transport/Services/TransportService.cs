using Domain.Filters;
using Domain.Helpers;
using Domain.Interfaces.Repository;
using Domain.Interfaces.Service;
using Domain.Models;
using Mapster;

namespace Application.Services
{
    public class TransportService : ITransportService
    {
        private readonly ITransportRepository _repository;        


        public TransportService(ITransportRepository repository)
        {
            _repository = repository;
        }


        public async Task<Transport> CreateAsync(Transport transport)
        {


            var newTransport = await _repository.AddAndSaveAsync(transport);

            return newTransport;
        }

        public async Task<bool> UpdateAsync(Transport transport)
        {

            await _repository.UpdateAsync(transport);

            return true;
        }

        public async Task<bool> DeleteAsync(Guid id)
        {

            await _repository.SoftDeleteGuidAsync(id);

            return true;
        }

        public async Task<PagedList<Transport>?> GetFilteredAsync(TransportFilter filter)
        {

            var result = await _repository.GetFilteredAsync(filter);

            if (result is null) return null;            

            return new PagedList<Transport>(result.Data, result.TotalCount, filter.PageNumber, filter.PageSize);
        }

        public async Task<Transport?> GetByIdAsync(Guid id)
        {

            var result = await _repository.GetByIdWithIncludeAsync(id);

            if (result == null)
                return null;


            return result;
        }

    }
}
