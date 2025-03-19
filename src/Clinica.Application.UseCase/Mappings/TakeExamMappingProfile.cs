using AutoMapper;
using Clinica.Application.Dtos.TakeExam.Response;
using Clinica.Application.UseCase.UseCases.TakeExam.Commands.ChangeStateCommand;
using Clinica.Application.UseCase.UseCases.TakeExam.Commands.CreateCommand;
using Clinica.Application.UseCase.UseCases.TakeExam.Commands.UpdateCommand;
using Clinica.Domain.Entities;

namespace Clinica.Application.UseCase.Mappings
{
    public class TakeExamMappingProfile : Profile
    {
        public TakeExamMappingProfile() { 
            CreateMap<GetTakeExamByIdResponseDto, TakeExam>().ReverseMap();
            CreateMap<GetTakeExamDetailByTakeExamIdResponseDto, TakeExamDetail>().ReverseMap();
            //Create
            CreateMap<CreateTakeExamCommand, TakeExam>();
            CreateMap<CreateTakeExamDetailCommand, TakeExamDetail>();
            //Update
            CreateMap<UpdateTakeExamCommand, TakeExam>();
            CreateMap<UpdateTakeExamDetailCommand, TakeExamDetail>();
            //ChangeState
            CreateMap<ChangeStateTakeExamCommand, TakeExam>();

        }
    }
}
