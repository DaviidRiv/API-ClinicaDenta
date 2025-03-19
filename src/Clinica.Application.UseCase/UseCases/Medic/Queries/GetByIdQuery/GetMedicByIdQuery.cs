using Clinica.Application.Dtos.Medic.Reponse;
using Clinica.Application.UseCase.Commons.Bases;
using MediatR;

namespace Clinica.Application.UseCase.UseCases.Medic.Queries.GetByIdQuery
{
    public class GetMedicByIdQuery : IRequest<BaseResponse<GetMedicByIdResponseDto>>
    {
        public int MedicId { get; set; }
    }
}
