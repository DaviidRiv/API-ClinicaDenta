using Clinica.Application.Dtos.Result.Response;
using Clinica.Application.UseCase.Commons.Bases;
using MediatR;

namespace Clinica.Application.UseCase.UseCases.Result.Queries.GetByIdQuery
{
    public class GetResultByIdQuery : IRequest<BaseResponse<GetResultByIdResponseDto>>
    {
        public int ResultId { get; set; }
    }
}
