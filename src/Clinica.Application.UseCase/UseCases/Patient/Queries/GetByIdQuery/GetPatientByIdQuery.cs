using Clinica.Application.Dtos.Patient.Reponse;
using Clinica.Application.UseCase.Commons.Bases;
using MediatR;

namespace Clinica.Application.UseCase.UseCases.Patient.Queries.GetByIdQuery
{
    public class GetPatientByIdQuery : IRequest<BaseResponse<GetPatientByIdResponseDto>>
    {
        public int PatientId {  get; set; }
    }
}
