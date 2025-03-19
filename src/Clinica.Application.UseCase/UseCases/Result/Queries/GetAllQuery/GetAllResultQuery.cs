using Clinica.Application.Dtos.Result.Response;
using Clinica.Application.UseCase.Commons.Bases;
using MediatR;

namespace Clinica.Application.UseCase.UseCases.Result.Queries.GetAllQuery
{
    public class GetAllResultQuery : IRequest<BasePaginationResponse<IEnumerable<GetAllResultResponseDto>>>
    {
        public int PageNumber { get; set; } = 1;
        public int PageSize { get; set; } = 10;
    }
}
