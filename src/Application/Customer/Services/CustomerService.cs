using Application.Contracts.Customer;
using Domain.Exceptions;
using Domain.Filters;
using Domain.Helpers;
using Domain.Interfaces.Helpers;
using Domain.Interfaces.Repository;
using Domain.Interfaces.Service;
using Domain.Models;
using Mapster;

namespace Application.Services
{
    public class CustomerService : ICustomerService
    {
        private readonly ICustomerRepository _repository;
        private readonly ICustomerAddressRepository _customerAddressRepository;
        private readonly IAddressRepository _addressRepository;
        private readonly IUserClaimsHelper _userClaim;
        private readonly IHashHelper _hash;
        private readonly IControlNumberHelper _control;
        private readonly ISendEmailService _mailService;
        private readonly IControlRepository _controlRepository;
        private readonly IUserRepository _userRepository;


        public CustomerService(ICustomerRepository repository, IUserClaimsHelper customerClaim, IHashHelper hash, IControlNumberHelper control, ISendEmailService mailService, IControlRepository controlRepository, IUserRepository userRepository, ICustomerAddressRepository customerAddressRepository, IAddressRepository addressRepository)
        {
            _repository = repository;
            _controlRepository = controlRepository;
            _userClaim = customerClaim;
            _hash = hash;
            _control = control;
            _mailService = mailService;
            _userRepository = userRepository;   
            _customerAddressRepository = customerAddressRepository;
            _addressRepository = addressRepository;
        }


        public async Task<Customer> CreateAsync(Customer customer)
        {
            // Verifica se já existe um Customer e um User com o mesmo e-mail
            var existingCustomer = await _repository.GetCustomerByEmailAsync(customer.Email!);
            var existingUser = await _userRepository.GetUserByEmailAsync(customer.Email!);

            if (existingCustomer is not null && existingUser is not null && existingUser.Password is not null)
            {
                throw new BlacktieNotAcceptableException("Já existe cliente cadastrado com este e-mail.");
            }

            // Criação ou reuso do objeto `User`
            var user = existingUser ?? new User
            {
                Email = customer.Email,
                Name = customer.Name,
            };

            // Adiciona o User ao repositório caso seja novo
            if (existingUser is null)
            {
                await _userRepository.AddAsync(user);
            }

            // Se não existir o Customer, cria um novo
            var newCustomer = existingCustomer ?? await _repository.AddAndSaveAsync(customer);

            newCustomer.UserId = user.Id;

            // Controle temporário e envio de e-mail
            newCustomer.TempControle = await CreateControlAndSendEmailAsync(user);

            return newCustomer;
        }




        public async Task<ResultWrapper<Customer>> UpdateAsync(Customer customerModified)
        {

            var existe = await _repository.GetCustomerByEmailAsync(customerModified.Email!);

            if (existe is not null && existe.Id != customerModified.Id)
            {
                throw new BlacktieNotAcceptableException("Já existe cliente cadastrado com este e-mail.");
            }

            var result = new ResultWrapper<Customer>(customerModified);
                       

            await UpdateAddressAsync(customerModified, result);

            await _repository.UpdateAsync(customerModified);

            return result;
        }

        public async Task DeleteAsync(Guid id)
        {
            var result = await GetByIdAsync(id);

            if (result == null)
                throw new CustomerNotFoundException();

            await _repository.SoftDeleteGuidAsync(result.Id);
        }


        public async Task<PagedList<Customer>?> GetFilteredAsync(CustomerFilter filter)
        {

            var result = await _repository.GetFilteredAsync(filter);

            if (result is null) return null;
            

            return new PagedList<Customer>(result.Data, result.TotalCount, filter.PageNumber, filter.PageSize);
        }

        public async Task<Customer?> GetByIdAsync(Guid id)
        {

            var customer = await _repository.GetByIdWithIncludeAsync(id);


            if (customer == null)
                return null;            

            return customer;
        }

        private async Task<int> CreateControlAndSendEmailAsync(User user)
        {
            var controle = _control.GetControlNumber();

            Control control = new Control
            {
                ExpireAt = DateTime.Now.AddMinutes(10),
                UserId = user.Id,
                ControlNumber = _hash.HashSHA256(Convert.ToString(controle))
            };

            await _controlRepository.AddAndSaveAsync(control);


            //EmailRequest email = new EmailRequest
            //{
            //    ToEmail = customer.Email,
            //    Subject = "Ativação de Acesso",
            //    Body = _mailService.CarregaCorpoEmail($"Por favor informe o código <b>{controle}</b> no local indicado no site.")
            //};

            //await _mailService.SendEmailAsync(email);

            return controle;
        }

        private async Task UpdateAddressAsync(Customer customerModified, ResultWrapper<Customer> result)
        {
            var customerAddressOriginal = await _customerAddressRepository.GetByCustomerIdAsync(customerModified.Id);

            var addressIdsModified = customerModified?.CustomerAddresses?.Where(x => x.AddressId != 0).Select(x => x.AddressId).ToList() ?? new List<int>();

            var customerAddressRemove = customerAddressOriginal?
                                    .Where(e => !addressIdsModified.Contains(e.AddressId)).ToList() ?? new List<CustomerAddress>();

            foreach (var customerAddress in customerAddressRemove)
            {                    
                await _customerAddressRepository.DeleteAsync(customerAddress);
            }

            foreach (var customerAddress in customerModified.CustomerAddresses.ToList())
            {
                if (customerAddress.AddressId == 0)
                {
                    var newAddress = await _addressRepository.AddAndSaveAsync(customerAddress.Address);
                    customerAddress.AddressId = newAddress.Id;
                    await _customerAddressRepository.AddAsync(new CustomerAddress() { AddressId = newAddress.Id, CustomerId = customerModified.Id });
                }
                else
                {
                    await _addressRepository.UpdateAsync(customerAddress.Address);
                }
            }
            
        }
    }
}
