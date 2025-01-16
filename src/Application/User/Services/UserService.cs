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
    public class UserService : IUserService
    {
        private readonly IUserRepository _repository;
        private readonly IUserClaimsHelper _userClaim;
        private readonly IHashHelper _hash;
        private readonly IControlNumberHelper _control;
        private readonly ISendEmailService _mailService;
        private readonly IControlRepository _controlRepository;


        public UserService(IUserRepository repository, IUserClaimsHelper userClaim, IHashHelper hash, IControlNumberHelper control, ISendEmailService mailService, IControlRepository controlRepository)
        {
            _repository = repository;
            _controlRepository = controlRepository;
            _userClaim = userClaim;
            _hash = hash;
            _control = control;
            _mailService = mailService;

        }


        public async Task<bool> CreateUserAsync(User user)
        {

            var existe = await _repository.GetUserByEmailAsync(user.Email!);

            if (existe is not null)
            {
                throw new BlacktieNotAcceptableException("Já existe usuário cadastrado com este e-mail.");
            }

            user = await _repository.AddAndSaveAsync(user);

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
            //    ToEmail = user.Email,
            //    Subject = "Ativação de Acesso",
            //    Body = _mailService.CarregaCorpoEmail($"Por favor informe o código <b>{controle}</b> no local indicado no site.")
            //};

            //await _mailService.SendEmailAsync(email);


            return true;
        }

        public async Task<bool> UpdateUserAsync(User user)
        {

            var existe = await _repository.GetUserByEmailAsync(user.Email!);

            if (existe is not null && existe.Id != user.Id)
            {
                throw new BlacktieNotAcceptableException("Já existe usuário cadastrado com este e-mail.");
            }

            await _repository.UpdateAsync(user);

            return true;
        }

        public async Task<bool> UpdateUserCredentialAsync(User user)
        {

            var existe = await _repository.GetUserByEmailAsync(user.Email!);

            if (existe is null)
            {
                throw new BlacktieNotAcceptableException("Não existe usuário cadastrado com este e-mail.");
            }

            var controle = _control.GetControlNumber();

            await _repository.UpdateAsync(user);

            Control control = new Control
            {
                ExpireAt = DateTime.Now.AddMinutes(10),
                UserId = user.Id,
                ControlNumber = _hash.HashSHA256(Convert.ToString(controle))
            };

            await _controlRepository.AddAndSaveAsync(control);

            EmailRequest email = new EmailRequest
            {
                ToEmail = user.Email,
                Subject = "Redefinir Senha",
                Body = _mailService.CarregaCorpoEmail($"Recebemos sua solicitação de redifinição de senha de acesso. Por favor informe o código <b>{controle}</b> no local indicado no site.")
            };

            await _mailService.SendEmailAsync(email);


            return true;
        }

        public async Task<User?> GetUserByEmailPassAsync(string email, string password)
        {
            var user = await _repository.GetUserByEmailPassAsync(email, password);

            return user;
        }

        public async Task<PagedList<User>?> GetFilteredAsync(UserFilter filter)
        {

            var result = await _repository.GetFilteredAsync(filter);

            if (result is null) return null;

            var mapped = result.Data.Adapt<List<User>>();



            return new PagedList<User>(mapped, result.TotalCount, filter.PageNumber, filter.PageSize);
        }

        public async Task<User?> GetUserByIdAsync(Guid id)
        {

            var result = await _repository.GetByGuidAsync(id);

            if (result == null)
                return null;


            return result;
        }

        public async Task<User?> GetUserByEmailAsync(string email)
        {

            var result = await _repository.GetUserByEmailAsync(email);

            if (result == null)
                return null;


            return result;
        }


    }
}
