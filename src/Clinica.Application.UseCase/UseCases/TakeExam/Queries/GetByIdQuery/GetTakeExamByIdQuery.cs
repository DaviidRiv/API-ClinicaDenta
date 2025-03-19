using Clinica.Application.Dtos.TakeExam.Response;
using Clinica.Application.UseCase.Commons.Bases;
using MediatR;

namespace Clinica.Application.UseCase.UseCases.TakeExam.Queries.GetByIdQuery
{
    public class GetTakeExamByIdQuery : IRequest<BaseResponse<GetTakeExamByIdResponseDto>>
    {
        public int TakeExamId { get; set; }
    }
}
