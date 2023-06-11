using FluentValidation;

namespace VouViajar.Excursoes.Application.Features.Commands.CadastrarExcursao
{
    public class CadastrarExcursaoValidator : AbstractValidator<CadastrarExcursaoCommand>
    {
        public CadastrarExcursaoValidator()
        {
            RuleFor(r => r.Nome).NotEmpty().WithMessage("Necessário informar o nome da excursão.");
            RuleFor(r => r.Resumo).NotEmpty().WithMessage("Necessário informar o reusmo da excursão.");
            RuleFor(r => r.DataInicio).NotEmpty().WithMessage("Necessário informar a data de início da excursão.");
            RuleFor(r => r.DataInicio).NotEmpty().WithMessage("Necessário informar a data do fim da excursão.");
        }
    }
}