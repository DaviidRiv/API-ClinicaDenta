using FluentValidation;

namespace Clinica.Application.UseCase.UseCases.Patient.Commands.CreateCommand
{
    public class CreatePatientValidator : AbstractValidator<CreatePatientCommand>
    {
        public CreatePatientValidator()
        {
            RuleFor(x => x.Names)
                .NotNull().WithMessage("El campo Nombres no puede ser nulo.")
                .NotEmpty().WithMessage("El campo Nombres no puede ser vacio.");

            RuleFor(x => x.LastName)
                .NotNull().WithMessage("El campo Apellido no puede ser nulo.")
                .NotEmpty().WithMessage("El campo Apellido no puede ser vacio.");

            RuleFor(x => x.MotherMaidenName)
                .NotNull().WithMessage("El campo Apellido Materno no puede ser nulo.")
                .NotEmpty().WithMessage("El campo Apellido Materno no puede ser vacio.");

            RuleFor(x => x.DocumentNumber)
                .NotNull().WithMessage("El campo Nº Documento no puede ser nulo.")
                .NotEmpty().WithMessage("El campo Nº Documento no puede ser vacio.")
                .Must(BeNumeric!).WithMessage("El campo Nº Documento debe contener solo números."); //Regla propia, para numeros

            RuleFor(x => x.Phone)
                .NotNull().WithMessage("El campo Teléfono no puede ser nulo.")
                .NotEmpty().WithMessage("El campo Teléfono no puede ser vacio.")
                .Must(BeNumeric!).WithMessage("El campo Teléfono debe contener solo números.");
        }

        private bool BeNumeric(string input)
        {
            return int.TryParse(input, out _);
        }
    }
}
