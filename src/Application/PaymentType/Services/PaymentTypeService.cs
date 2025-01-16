using Domain.Filters;
using Domain.Helpers;
using Domain.Interfaces.Repository;
using Domain.Interfaces.Service;
using Domain.Models;

namespace Application.Services
{
    public class PaymentTypeService : IPaymentTypeService
    {
        private readonly IPaymentTypeRepository _repository;


        public PaymentTypeService(IPaymentTypeRepository repository)
        {
            _repository = repository;
        }


        public async Task<PaymentType> CreateAsync(PaymentType paymenttype)
        {


            var newPaymentType = await _repository.AddAndSaveAsync(paymenttype);

            return newPaymentType;
        }

        public async Task<bool> UpdateAsync(PaymentType paymenttype)
        {

            await _repository.UpdateAsync(paymenttype);

            return true;
        }

        public async Task<bool> DeleteAsync(int id)
        {

            await _repository.SoftDeleteAsync(id);

            return true;
        }

        public async Task<PagedList<PaymentType>?> GetFilteredAsync(GenericFilter filter)
        {

            var result = await _repository.GetFilteredAsync(filter);

            if (result is null) return null;

            return new PagedList<PaymentType>(result.Data, result.TotalCount, filter.PageNumber, filter.PageSize);
        }

        public async Task<PaymentType?> GetByIdAsync(int id)
        {

            var result = await _repository.GetByIdAsync(id);

            if (result == null)
                return null;


            return result;
        }

    }
}
