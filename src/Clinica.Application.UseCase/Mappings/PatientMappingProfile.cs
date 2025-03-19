using AutoMapper;
using Clinica.Application.Dtos.Patient.Reponse;
using Clinica.Application.UseCase.UseCases.Patient.Commands.ChangeStateCommand;
using Clinica.Application.UseCase.UseCases.Patient.Commands.CreateCommand;
using Clinica.Application.UseCase.UseCases.Patient.Commands.UpdateCommand;
using Clinica.Domain.Entities;

namespace Clinica.Application.UseCase.Mappings
{
    public class PatientMappingProfile : Profile
    {
        public PatientMappingProfile()
        {
            CreateMap<Patient, GetPatientByIdResponseDto>().ReverseMap();
            CreateMap<CreatePatientCommand, Patient>();
            CreateMap<UpdatePatientCommand, Patient>();
            CreateMap<ChangeStatePatientCommand, Patient>();
        }
    }
}
