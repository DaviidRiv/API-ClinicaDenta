using Clinica.Application.Dtos.Exam.Response;
using Clinica.Application.UseCase.Commons.Bases;
using MediatR;

namespace Clinica.Application.UseCase.UseCases.Exam.Queries.GetByIdQuery
{
    public class GetExamByIdQuery : IRequest<BaseResponse<GetExamByIdResponseDto>>
    {
        public int ExamId { get; set; }
    }
}
