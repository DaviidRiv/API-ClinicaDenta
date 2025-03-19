using Clinica.Application.UseCase.Commons.Bases;
using Clinica.Application.Dtos.Analysis.Response;
using MediatR;


namespace Clinica.Application.UseCase.UseCases.Analysis.Queries.GetByIdQuery
{
    public class GetAnalysisByIdQuery : IRequest<BaseResponse<GetAnalysisByIdResponseDto>>
    {
        public int AnalysisId { get; set; } 

    }
}
