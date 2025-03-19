using Clinica.Application.Dtos.Exam.Response;
using Clinica.Application.Interface.Interfaces;
using Clinica.Domain.Entities;
using Clinica.Persistence.Context;
using Dapper;
using System.Data;

namespace Clinica.Persistence.Repositories
{
    public class ExamRepository : GenericRepository<Exam>, IExamRepository
    {
        private readonly ApplicationDbContext _context;

        public ExamRepository(ApplicationDbContext context) : base(context)
        {
            _context = context;
        }

        public async Task<IEnumerable<GetAllExamResponseDto>> GetAllExams(string storedProcedure, object parameter)
        {
            using var conn = _context.CreateConnection;
            var objParam = new DynamicParameters(parameter);
            var exams = await conn.QueryAsync<GetAllExamResponseDto>(storedProcedure, param: objParam, commandType: CommandType.StoredProcedure);
            return exams;
        }
    }
}
