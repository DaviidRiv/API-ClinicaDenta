using Clinica.Application.Dtos.TakeExam.Response;
using Clinica.Domain.Entities;

namespace Clinica.Application.Interface.Interfaces
{
    public interface ITakeExamRepository : IGenericRepository<TakeExam>
    {
        Task<IEnumerable<GetAllTakeExamResponseDto>> GetAllTakeExams( string storedProcedure, object parameter);
        Task<TakeExam> GetTakeExamById(int takeExamId);
        Task<IEnumerable<TakeExamDetail>> GetTakeExamDetailByTakeExamId(int takeExamId);
        Task<TakeExam> RegisterTakeExam(TakeExam takeExam);
        Task RegisterTakeExamDetail(TakeExamDetail takeExamDetail);
        Task UpdateTakeExam(TakeExam takeExam);
        Task UpdateTakeExamDetail(TakeExamDetail takeExamDetail);
        Task<bool> ChangeStateTakeExam (TakeExam takeExam);
    }
}
