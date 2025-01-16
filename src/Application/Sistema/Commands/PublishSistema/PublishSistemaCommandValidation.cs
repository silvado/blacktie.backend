using FluentValidation;
using System.Diagnostics.CodeAnalysis;

namespace Application.Commands.PublishSistema
{
    [ExcludeFromCodeCoverage]
    public class PublishSistemaCommandValidation : AbstractValidator<PublishSistemaCommand>
    {
        public PublishSistemaCommandValidation()
        {
            RuleFor(x => x.item.NomeSistema)
                .NotEmpty().WithMessage("Nome do Sistema é obrigatório.")
                .MaximumLength(200).WithMessage("Nome do Sistema deve conter no máximo 200 caracteres.");

            RuleFor(x => x.item.SiglaSistema)
                .NotEmpty().WithMessage("Sigla do Sistema é obrigatória.")
                .MaximumLength(10).WithMessage("Sigla do Sistema deve conter no máximo 10 caracteres.");

            RuleFor(x => x.item.Configuracao)
               .NotEmpty().WithMessage("Configuração é obrigatória.");
        }
    }
}
