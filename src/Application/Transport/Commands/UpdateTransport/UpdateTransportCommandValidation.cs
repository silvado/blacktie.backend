using FluentValidation;

namespace Application.Commands.UpdateTransport
{
    public class UpdateTransportCommandValidation : AbstractValidator<UpdateTransportCommand>
    {
        public UpdateTransportCommandValidation()
        {
            RuleFor(x => x.item.Name)
                .NotEmpty().WithMessage("Nome é obrigatório.")
                .MaximumLength(100).WithMessage("Nome deve conter no máximo 100 caracteres.");

            RuleFor(x => x.item.Brand)
               .NotEmpty().WithMessage("Marca é obrigatório.")
               .MaximumLength(50).WithMessage("Marca deve conter no máximo 50 caracteres.");
        }
    }
}
