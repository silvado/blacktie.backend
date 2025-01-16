using Domain.Filters;
using Domain.Helpers;
using Domain.Models;

namespace Domain.Interfaces.Service
{
    public interface IFromToService
    {
        Task<FromTo> CreateAsync(FromTo fromto);
        Task<bool> UpdateAsync(FromTo fromto);
        Task<bool> DeleteAsync(int id);
        Task<PagedList<FromTo>?> GetFilteredAsync(GenericFilter filter);
        Task<FromTo?> GetByIdAsync(int id);
    }
}
