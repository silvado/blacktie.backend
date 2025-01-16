using Domain.Enums;
using Domain.Exceptions;
using Domain.Filters;
using Domain.Helpers;
using Domain.Interfaces.Repository;
using Domain.Interfaces.Service;
using Domain.Models;

namespace Application.Services
{
    public class OrderService : IOrderService
    {
        private readonly IOrderRepository _repository;
        private readonly IUserRepository _userRepository;
        private readonly ICustomerRepository _customerRepository;
        private readonly IProductRepository _productRepository;

        public OrderService(IOrderRepository repository, IUserRepository userRepository, ICustomerRepository customerRepository, IProductRepository productRepository)
        {
            _repository = repository;
            _userRepository = userRepository;   
            _customerRepository = customerRepository;
            _productRepository = productRepository;
        }


        public async Task<Order> CreateAsync(Order order, Guid userId)
        {

            if (userId == Guid.Empty) { throw new ArgumentNullException(nameof(userId)); }

            var user = await _userRepository.GetByGuidAsync(userId);

            if (user == null) { throw new ArgumentNullException(nameof(user)); }

            CustomerFilter filter = new CustomerFilter()
            {
                Email = user.Email
            };

            var customer = await _customerRepository.GetFilteredAsync(filter);

            if (customer != null && customer.Data == null) {
                throw new BlacktieNotAcceptableException("Cliente não encontrado.");
            }

            var product = await _productRepository.GetByGuidAsync(order.ProductId);

            if (product == null) {
                throw new BlacktieNotAcceptableException("Produto não encontrado.");
            }
            order.Date = DateTime.Now;
            order.ProductId = product.Id;
            order.Price = product?.Price ?? 0;  
            order.Amount = 1;
            order.CustomerId = customer!.Data[0].Id;
            order.ExpireAt = DateTime.Now.AddMinutes(20);
            order.PaymentStatus = EPaymentStatus.Waiting;
            
            var newOrder = await _repository.AddAndSaveAsync(order);

            return newOrder;
        }

        public async Task<bool> UpdateAsync(Order order)
        {

            var actual = await _repository.GetByGuidAsync(order.Id);

            if (actual == null)
                throw new OrderNotFoundException();

            if (order.PaymentStatus == EPaymentStatus.Waiting && actual.ExpireAt > DateTime.Now)
            {
                order.PaymentStatus = EPaymentStatus.Canceled;
                
                await _repository.UpdateAsync(order);

                throw new BlacktieNotAcceptableException("Pedido expirado.");

            }

            await _repository.UpdateAsync(order);

            return true;
        }

        public async Task<bool> DeleteAsync(Guid id)
        {

            await _repository.SoftDeleteGuidAsync(id);

            return true;
        }

        public async Task<PagedList<Order>?> GetFilteredAsync(OrderFilter filter)
        {

            var result = await _repository.GetFilteredAsync(filter);

            if (result is null) return null;

            return new PagedList<Order>(result.Data, result.TotalCount, filter.PageNumber, filter.PageSize);
        }

        public async Task<Order?> GetByIdAsync(Guid id)
        {

            var result = await _repository.GetByIdWithIncludeAsync(id);

            if (result == null)
                return null;


            return result;
        }
    }
}
