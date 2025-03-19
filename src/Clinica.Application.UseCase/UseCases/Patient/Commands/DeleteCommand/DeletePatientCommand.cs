using Clinica.Application.UseCase.Commons.Bases;
using MediatR;

namespace Clinica.Application.UseCase.UseCases.Patient.Commands.DeleteCommand
{
    public class DeletePatientCommand : IRequest<BaseResponse<bool>>
    {
        public int PatientId { get; set; } //Unico atributo que introduce el user
    }
}