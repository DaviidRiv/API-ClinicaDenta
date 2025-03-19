using FluentValidation;

namespace Clinica.Application.UseCase.UseCases.Exam.Commands.CreateCommand
{
    public class CreateExamValidator : AbstractValidator<CreateExamCommand>
    {
        public CreateExamValidator()
        {
            RuleFor(x => x.Name)
                .NotNull().WithMessage("El campo nombre no puede ser nulo.")
                .NotEmpty().WithMessage("El campo nombre no puede ser vacio.");

            //Si se requiere validar que solo un idAnalysis por Examen aqui es:
        }
    }
}
