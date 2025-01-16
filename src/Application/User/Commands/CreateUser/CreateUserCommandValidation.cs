using FluentValidation;

namespace Application.Commands.CreateUser
{
    public class CreateUserCommandValidation : AbstractValidator<CreateUserCommand>
    {
        public CreateUserCommandValidation()
        {
            RuleFor(x => x.item.Name)
                .NotEmpty().WithMessage("Nome é obrigatório.")
                .MaximumLength(100).WithMessage("Nome deve conter no máximo 100 caracteres.");           

            RuleFor(x => x.item.Email)
               .NotEmpty().WithMessage("E-mail é obrigatório.")
               .MaximumLength(50).WithMessage("Usuário deve conter no máximo 50 caracteres.");
        }
    }
}
