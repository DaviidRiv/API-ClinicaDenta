using AutoMapper;
using Clinica.Application.UseCase.UseCases.User.Command.CreateCommand;
using Clinica.Domain.Entities;

namespace Clinica.Application.UseCase.Mappings
{
    public class UserMappingProfile : Profile
    {
        public UserMappingProfile()
        {
            CreateMap<CreateUserCommand, User>();
        }
    }
}
