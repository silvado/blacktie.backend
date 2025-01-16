using FluentValidation;

namespace Application.Commands.CreateUnavailableDate
{
    public class CreateUnavailableDateCommandValidation : AbstractValidator<CreateUnavailableDateCommand>
    {
        public CreateUnavailableDateCommandValidation()
        {
            RuleFor(x => x.item.Year)
                .NotEmpty().WithMessage("Ano é obrigatório.");
            RuleFor(x => x.item.StartAt)
                .NotEmpty().WithMessage("Data inicial é obrigatória.");
        }
    }
}
