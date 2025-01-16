using FluentValidation;

namespace Application.Commands.UpdateUnavailableDate
{
    public class UpdateUnavailableDateCommandValidation : AbstractValidator<UpdateUnavailableDateCommand>
    {
        public UpdateUnavailableDateCommandValidation()
        {
            RuleFor(x => x.item.Year)
               .NotEmpty().WithMessage("Ano é obrigatório.");
            RuleFor(x => x.item.StartAt)
                .NotEmpty().WithMessage("Data inicial é obrigatória.");
        }
    }
}
