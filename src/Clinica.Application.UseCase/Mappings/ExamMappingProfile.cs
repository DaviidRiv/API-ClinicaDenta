using AutoMapper;
using Clinica.Application.Dtos.Exam.Response;
using Clinica.Application.UseCase.UseCases.Exam.Commands.ChangeStateCommand;
using Clinica.Application.UseCase.UseCases.Exam.Commands.CreateCommand;
using Clinica.Application.UseCase.UseCases.Exam.Commands.UpdateCommand;
using Clinica.Domain.Entities;

namespace Clinica.Application.UseCase.Mappings
{
    public class ExamMappingProfile : Profile
    {
        public ExamMappingProfile()
        {
            CreateMap<Exam, GetExamByIdResponseDto>().ReverseMap();
            CreateMap<CreateExamCommand, Exam>();
            CreateMap<UpdateExamCommand, Exam>();
            CreateMap<ChangeStateExamCommand, Exam>();
        }
    }
}
