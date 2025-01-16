using Domain.Filters;
using Domain.Helpers;
using Domain.Interfaces.Repository;
using Domain.Interfaces.Service;
using Domain.Models;

namespace Application.Services
{
    public class FromToService: IFromToService
    {
        private readonly IFromToRepository _repository;


        public FromToService(IFromToRepository repository)
        {
            _repository = repository;
        }


        public async Task<FromTo> CreateAsync(FromTo fromto)
        {


            var newFromTo = await _repository.AddAndSaveAsync(fromto);

            return newFromTo;
        }

        public async Task<bool> UpdateAsync(FromTo fromto)
        {

            await _repository.UpdateAsync(fromto);

            return true;
        }

        public async Task<bool> DeleteAsync(int id)
        {

            await _repository.SoftDeleteAsync(id);

            return true;
        }

        public async Task<PagedList<FromTo>?> GetFilteredAsync(GenericFilter filter)
        {

            var result = await _repository.GetFilteredAsync(filter);

            if (result is null) return null;

            return new PagedList<FromTo>(result.Data, result.TotalCount, filter.PageNumber, filter.PageSize);
        }

        public async Task<FromTo?> GetByIdAsync(int id)
        {

            var result = await _repository.GetByIdAsync(id);

            if (result == null)
                return null;


            return result;
        }

    }
}
