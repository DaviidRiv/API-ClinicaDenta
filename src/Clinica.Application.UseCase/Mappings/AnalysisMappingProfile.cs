using AutoMapper;
using Clinica.Application.Dtos.Analysis.Response;
using Clinica.Application.UseCase.UseCases.Analysis.Commands.ChangeStateCommand;
using Clinica.Application.UseCase.UseCases.Analysis.Commands.CreateCommand;
using Clinica.Application.UseCase.UseCases.Analysis.Commands.UpdateCommand;
using Clinica.Domain.Entities;

namespace Clinica.Application.UseCase.Mappings
{
    public class AnalysisMappingProfile : Profile
    {
        public AnalysisMappingProfile()
        {
            CreateMap<Analysis, GetAllAnalysisResponseDto>()
                .ForMember(x => x.StateAnalysis, x => x.MapFrom(y => y.State == 1 ? "ACTIVO" : "INACTIVO"))
                .ReverseMap();

            CreateMap<Analysis, GetAnalysisByIdResponseDto>().ReverseMap();

            CreateMap<CreateAnalysisCommand, Analysis>();

            CreateMap<UpdateAnalysisCommand, Analysis>();

            CreateMap<ChangeStateAnalysisCommand, Analysis>();
        }
    }
}
