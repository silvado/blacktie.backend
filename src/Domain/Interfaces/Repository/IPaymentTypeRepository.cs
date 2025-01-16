using Domain.Filters;
using Domain.Helpers;
using Domain.Interfaces.Common;
using Domain.Models;

namespace Domain.Interfaces.Repository
{
    public interface IPaymentTypeRepository : IGenericAsyncRepository<PaymentType>
    {
        Task<PagedList<PaymentType>?> GetFilteredAsync(GenericFilter filter);
    }
}
