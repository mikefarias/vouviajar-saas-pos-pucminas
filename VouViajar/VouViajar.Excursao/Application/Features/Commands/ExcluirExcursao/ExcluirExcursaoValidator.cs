using FluentValidation;

namespace VouViajar.Excursoes.Application.Features.Commands.ExcluirExcursao
{
    public class ExcluirExcursaoValidator : AbstractValidator<ExcluirExcursaoCommand>
    {
        public ExcluirExcursaoValidator()
        {
            RuleFor(r => r.ID).GreaterThan(0).WithMessage("Necessário informar ID maior que zero.");
        }
    }
}
