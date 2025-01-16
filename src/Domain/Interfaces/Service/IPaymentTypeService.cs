using Domain.Filters;
using Domain.Helpers;
using Domain.Models;

namespace Domain.Interfaces.Service
{
    public interface IPaymentTypeService
    {
        Task<PaymentType> CreateAsync(PaymentType paymenttype);
        Task<bool> UpdateAsync(PaymentType paymenttype);
        Task<bool> DeleteAsync(int id);
        Task<PagedList<PaymentType>?> GetFilteredAsync(GenericFilter filter);
        Task<PaymentType?> GetByIdAsync(int id);
    }
}
