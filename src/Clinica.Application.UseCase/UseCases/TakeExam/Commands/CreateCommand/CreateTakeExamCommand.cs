using Clinica.Application.UseCase.Commons.Bases;
using MediatR;

namespace Clinica.Application.UseCase.UseCases.TakeExam.Commands.CreateCommand
{
    public class CreateTakeExamCommand : IRequest<BaseResponse<bool>>
    {
        public int PatientId { get; set; }
        public int MedicId { get; set; }
        public IEnumerable<CreateTakeExamDetailCommand>? TakeExamDetails { get; set; }
    }

    public class CreateTakeExamDetailCommand
    {
        public int ExamId { get; set; }
        public int AnalysisId { get; set; }
    }
}
