using Clinica.Application.UseCase.Commons.Bases;
using MediatR;

namespace Clinica.Application.UseCase.UseCases.TakeExam.Commands.ChangeStateCommand
{
    public class ChangeStateTakeExamCommand : IRequest<BaseResponse<bool>>
    {
        public int TakeExamId { get; set; }
        public int State { get; set; }
    }
}
