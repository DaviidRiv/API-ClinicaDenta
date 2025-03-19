using Clinica.Application.Dtos.Patient.Reponse;
using Clinica.Application.UseCase.Commons.Bases;
using MediatR;

namespace Clinica.Application.UseCase.UseCases.Patient.Queries.GetAllQuery
{
    public class GetAllPatientQuery : IRequest<BasePaginationResponse<IEnumerable<GetAllPatientResponseDto>>>
    {
        public int PageNumber { get; set; } = 1;
        public int PageSize { get; set; } = 10;
    }
}
