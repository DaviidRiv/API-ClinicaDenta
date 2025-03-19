using Clinica.Application.Dtos.Exam.Response;
using Clinica.Domain.Entities;

namespace Clinica.Application.Interface.Interfaces
{
    public interface IExamRepository : IGenericRepository<Exam>
    {
        Task<IEnumerable<GetAllExamResponseDto>> GetAllExams(string storedProcedure, object parameter);
    }
}
