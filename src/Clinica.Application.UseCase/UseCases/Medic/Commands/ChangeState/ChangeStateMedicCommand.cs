using Clinica.Application.UseCase.Commons.Bases;
using MediatR;

namespace Clinica.Application.UseCase.UseCases.Medic.Commands.ChangeState
{
    public class ChangeStateMedicCommand : IRequest<BaseResponse<bool>>
    {
        public int MedicId { get; set; }
        public int State { get; set; }
    }
}
