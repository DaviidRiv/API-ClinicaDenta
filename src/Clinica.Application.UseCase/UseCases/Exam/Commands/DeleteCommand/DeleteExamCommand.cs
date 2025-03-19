using Clinica.Application.UseCase.Commons.Bases;
using MediatR;

namespace Clinica.Application.UseCase.UseCases.Exam.Commands.DeleteCommand
{
    public class DeleteExamCommand : IRequest<BaseResponse<bool>>
    {
        public int ExamId { get; set; } //Unico atributo que introduce el user
    }
}
