using Clinica.Application.Dtos.TakeExam.Response;
using Clinica.Application.Interface.Interfaces;
using Clinica.Domain.Entities;
using Clinica.Persistence.Context;
using Dapper;
using System.Data;

namespace Clinica.Persistence.Repositories
{
    public class TakeExamRepository : GenericRepository<TakeExam>, ITakeExamRepository
    {
        private readonly ApplicationDbContext _context;

        public TakeExamRepository(ApplicationDbContext context) : base(context)
        {
            _context = context;
        }

        public async Task<IEnumerable<GetAllTakeExamResponseDto>> GetAllTakeExams(string storedProcedure, object parameter)
        {
            using var conn = _context.CreateConnection;
            var objParam = new DynamicParameters(parameter);
            var takeExams = await conn.QueryAsync<GetAllTakeExamResponseDto>(storedProcedure, param: objParam, commandType: CommandType.StoredProcedure);
            return takeExams;
        }

        //Query a la base de datos
        public async Task<TakeExam> GetTakeExamById(int takeExamId)
        {
            using var conn = _context.CreateConnection;
            var sql = @"SELECT TakeExamid, PatientId, MedicId FROM TakeExam WHERE TakeExamId = @takeExamId";
            var parameters = new DynamicParameters();
            parameters.Add("TakeExamId", takeExamId);
            var takeExam = await conn.QuerySingleOrDefaultAsync<TakeExam>(sql, param: parameters);

            return takeExam;
        }

        public async Task<IEnumerable<TakeExamDetail>> GetTakeExamDetailByTakeExamId(int takeExamId)
        {
            using var conn = _context.CreateConnection;
            var sql = @"SELECT TakeExamDetailId, TakeExamId, ExamId, AnalysisId FROM TakeExamDetail WHERE TakeExamId = @takeExamId";
            var parameters = new DynamicParameters();
            parameters.Add("TakeExamId", takeExamId);
            var takeExamDetail = await conn.QueryAsync<TakeExamDetail>(sql, param: parameters);

            return takeExamDetail;
        }

        public async Task<TakeExam> RegisterTakeExam(TakeExam takeExam)
        {
            using var conn = _context.CreateConnection;
            var sql = @"INSERT INTO TakeExam (PatientId, MedicId, State, AuditCreateDate) 
                        VALUES (@PatientId, @MedicId, @State, @AuditCreateDate); 
                        SELECT CAST(SCOPE_IDENTITY() as int)";
            var parameters = new DynamicParameters();
            parameters.Add("PatientId", takeExam.PatientId);
            parameters.Add("MedicId", takeExam.MedicId);
            parameters.Add("State", 1);
            parameters.Add("AuditCreateDate", DateTime.Now);

            var takeExamId = await conn.QuerySingleOrDefaultAsync<int>(sql, param: parameters);
            takeExam.TakeExamId = takeExamId;
            return takeExam;
        }

        public async Task RegisterTakeExamDetail(TakeExamDetail takeExamDetail)
        {
            using var conn = _context.CreateConnection;
            var sql = @"INSERT INTO TakeExamDetail (TakeExamId, ExamId, AnalysisId) 
                        VALUES (@TakeExamId, @ExamId, @AnalysisId)";
            var parameters = new DynamicParameters();
            parameters.Add("TakeExamId", takeExamDetail.TakeExamId);
            parameters.Add("ExamId", takeExamDetail.ExamId);
            parameters.Add("AnalysisId", takeExamDetail.AnalysisId);

            await conn.ExecuteAsync(sql, param: parameters);
        }

        public async Task UpdateTakeExam(TakeExam takeExam)
        {
            using var conn = _context.CreateConnection;
            var sql = @"UPDATE TakeExam SET PatientId = @PatientId, MedicId = @MedicId
                        WHERE TakeExamId = @TakeExamId";
            var parameters = new DynamicParameters();
            parameters.Add("PatientId", takeExam.PatientId);
            parameters.Add("MedicId", takeExam.MedicId);
            parameters.Add("TakeExamId", takeExam.TakeExamId);
            await conn.ExecuteAsync(sql, param: parameters);
        }

        public async Task UpdateTakeExamDetail(TakeExamDetail takeExamDetail)
        {
            using var conn = _context.CreateConnection;
            var sql = @"UPDATE TakeExamDetail SET ExamId = @ExamId, AnalysisId = @AnalysisId 
                        WHERE TakeExamDetailId = @TakeExamDetailId";
            var parameters = new DynamicParameters();
            parameters.Add("ExamId", takeExamDetail.ExamId);
            parameters.Add("AnalysisId", takeExamDetail.AnalysisId);
            parameters.Add("TakeExamDetailId", takeExamDetail.TakeExamDetailId);
            await conn.ExecuteAsync(sql, param: parameters);
        }

        public async Task<bool> ChangeStateTakeExam(TakeExam takeExam)
        {
            var conn = _context.CreateConnection;
            var sql = @"UPDATE TakeExam SET State = @State WHERE TakeExamId = @TakeExamId";
            var parameters = new DynamicParameters();
            parameters.Add("State", takeExam.State);
            parameters.Add("TakeExamId", takeExam.TakeExamId);
            var result = await conn.ExecuteAsync(sql, param: parameters);
            return result > 0;
        }
    }
}