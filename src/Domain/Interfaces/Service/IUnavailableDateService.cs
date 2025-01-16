using Domain.Filters;
using Domain.Helpers;
using Domain.Models;

namespace Domain.Interfaces.Service
{
    public interface IUnavailableDateService
    {
        Task<UnavailableDate> CreateAsync(UnavailableDate unavailabledate);
        Task<bool> UpdateAsync(UnavailableDate unavailabledate);
        Task<bool> DeleteAsync(int id);
        Task<PagedList<UnavailableDate>?> GetFilteredAsync(UnavailableDateFilter filter);
        Task<UnavailableDate?> GetByIdAsync(int id);
    }
}
