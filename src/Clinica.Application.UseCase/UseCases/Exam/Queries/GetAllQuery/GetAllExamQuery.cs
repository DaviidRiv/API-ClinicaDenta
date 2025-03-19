using Clinica.Application.Dtos.Exam.Response;
using Clinica.Application.UseCase.Commons.Bases;
using MediatR;

namespace Clinica.Application.UseCase.UseCases.Exam.Queries.GetAllQuerie
{
    public class GetAllExamQuery : IRequest<BasePaginationResponse<IEnumerable<GetAllExamResponseDto>>>
    {
        public int PageNumber { get; set; } = 1;
        public int PageSize { get; set; } = 10;
    }
}
