using AutoMapper;
using Clinica.Application.Dtos.Result.Response;
using Clinica.Application.UseCase.UseCases.Result.Commands.CreateCommand;
using Clinica.Application.UseCase.UseCases.Result.Commands.UpdateCommand;
using Clinica.Domain.Entities;

namespace Clinica.Application.UseCase.Mappings
{
    public class ResultMappingProfile : Profile
    {
        public ResultMappingProfile()
        {
            CreateMap<Result, GetResultByIdResponseDto>().ReverseMap();
            CreateMap<ResultDetail, GetResultDetailByResultIdResponseDto>().ReverseMap();

            CreateMap<CreateResultCommand, Result>();
            CreateMap<CreateResultDetailCommand, ResultDetail>();//New Map

            CreateMap<UpdateResultCommand, Result>();
            CreateMap<UpdateResultDetailCommand, ResultDetail>();

        }
    }
}
