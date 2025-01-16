using FluentValidation;

namespace Application.Commands.UpdateFromTo
{
    public class UpdateFromToCommandValidation : AbstractValidator<UpdateFromToCommand>
    {
        public UpdateFromToCommandValidation()
        {
            RuleFor(x => x.item.Name)
                .NotEmpty().WithMessage("Nome é obrigatório.")
                .MaximumLength(200).WithMessage("Nome conter no máximo 100 caracteres.");
        }
    }
}
