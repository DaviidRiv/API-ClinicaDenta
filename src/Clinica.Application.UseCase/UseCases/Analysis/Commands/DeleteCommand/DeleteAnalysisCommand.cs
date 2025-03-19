using Clinica.Application.UseCase.Commons.Bases;
using MediatR;

namespace Clinica.Application.UseCase.UseCases.Analysis.Commands.DeleteCommand
{
    public class DeleteAnalysisCommand : IRequest<BaseResponse<bool>>
    {
        public int AnalysisId { get; set; } //Unico atributo que introduce el user
    }
}
