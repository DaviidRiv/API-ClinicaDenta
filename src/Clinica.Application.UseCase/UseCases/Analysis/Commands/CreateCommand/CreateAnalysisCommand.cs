using Clinica.Application.UseCase.Commons.Bases;
using MediatR;

namespace Clinica.Application.UseCase.UseCases.Analysis.Commands.CreateCommand
{
    public class CreateAnalysisCommand : IRequest<BaseResponse<bool>> //bool respuesta
    {
        public string? AnalysisName { get; set; } //Unico atributo que introduce el user
    }
}
