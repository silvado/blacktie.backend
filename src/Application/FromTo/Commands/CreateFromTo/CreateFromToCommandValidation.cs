using FluentValidation;

namespace Application.Commands.CreateFromTo
{
    public class CreateFromToCommandValidation : AbstractValidator<CreateFromToCommand>
    {
        public CreateFromToCommandValidation()
        {
            RuleFor(x => x.item.Name)
                .NotEmpty().WithMessage("Nome é obrigatório.")
                .MaximumLength(200).WithMessage("Nome conter no máximo 100 caracteres.");
        }
    }
}
