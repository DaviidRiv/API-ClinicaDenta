using AutoMapper;
using Clinica.Application.Dtos.Medic.Reponse;
using Clinica.Application.UseCase.UseCases.Medic.Commands.ChangeState;
using Clinica.Application.UseCase.UseCases.Medic.Commands.CreateCommand;
using Clinica.Application.UseCase.UseCases.Medic.Commands.DeleteCommand;
using Clinica.Application.UseCase.UseCases.Medic.Commands.UpdateCommand;
using Clinica.Domain.Entities;

namespace Clinica.Application.UseCase.Mappings
{
    public class MedicMappingProfile : Profile
    {
        public MedicMappingProfile()
        {
            CreateMap<Medic, GetMedicByIdResponseDto>().ReverseMap();
            CreateMap<CreateMedicCommand, Medic>();
            CreateMap<UpdateMedicCommand, Medic>();
            CreateMap<DeleteMedicCommand, Medic>();
            CreateMap<ChangeStateMedicCommand, Medic>();
        }
    }
}
