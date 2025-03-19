using FluentValidation;

namespace Clinica.Application.UseCase.UseCases.Analysis.Commands.CreateCommand
{
    public class CreateAnalysisValidator : AbstractValidator<CreateAnalysisCommand>
    {
        public CreateAnalysisValidator()
        {
            RuleFor(x => x.AnalysisName)
                .NotNull().WithMessage("El campo AnalysisName no puede ser nulo.")
                .NotEmpty().WithMessage("El campo AnalysisName no puede ser vacio.");
        }
    }
}
