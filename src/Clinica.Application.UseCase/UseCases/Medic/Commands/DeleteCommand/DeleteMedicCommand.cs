using Clinica.Application.UseCase.Commons.Bases;
using MediatR;

namespace Clinica.Application.UseCase.UseCases.Medic.Commands.DeleteCommand
{
    public class DeleteMedicCommand : IRequest<BaseResponse<bool>>
    {
        public int MedicId { get; set; } //Unico atributo que introduce el user
    }
}