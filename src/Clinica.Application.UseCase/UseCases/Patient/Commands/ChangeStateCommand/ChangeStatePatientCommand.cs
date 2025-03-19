using Clinica.Application.UseCase.Commons.Bases;
using MediatR;

namespace Clinica.Application.UseCase.UseCases.Patient.Commands.ChangeStateCommand
{
    public class ChangeStatePatientCommand : IRequest<BaseResponse<bool>>
    {
        public int PatientId { get; set; }
        public int State { get; set; }
    }
}
