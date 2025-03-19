using Clinica.Application.Dtos.Result.Response;
using Clinica.Application.Interface.Interfaces;
using Clinica.Domain.Entities;
using Clinica.Persistence.Context;
using Dapper;
using System.Data;

namespace Clinica.Persistence.Repositories
{
    public class ResultRepository : GenericRepository<Result>, IResultRepository
    {
        private readonly ApplicationDbContext _context;

        public ResultRepository(ApplicationDbContext context) : base(context)
        {
            _context = context;
        }

        public async Task<IEnumerable<GetAllResultResponseDto>> GetAllResults(string sp, object parameters)
        {
            var conn = _context.CreateConnection;
            var objParam = new DynamicParameters(parameters);
            var results = await conn.QueryAsync<GetAllResultResponseDto>(sp, param: objParam, commandType: CommandType.StoredProcedure);
            return results;
        }

        public async Task<Result> GetResultById(int resultId)
        {
            var conn = _context.CreateConnection;
            var sql = $"SELECT ResultId, TakeExamId FROM Results WHERE ResultId = @ResultId";
            var parameters = new DynamicParameters();
            parameters.Add("@ResultId", resultId);
            var result = await conn.QuerySingleOrDefaultAsync<Result>(sql, param: parameters);
            return result;
        }

        public async Task<IEnumerable<ResultDetail>> GetResultDetailByResultId(int resultId)
        {
            var conn = _context.CreateConnection;
            var sql = $"SELECT ResultDetailId, ResultId, ResultFile, TakeExamDetailId FROM ResultDetail WHERE ResultId = @ResultId";
            var parameters = new DynamicParameters();
            parameters.Add("@ResultId", resultId);
            var resultDetails = await conn.QueryAsync<ResultDetail>(sql, param: parameters);
            return resultDetails;
        }

        public async Task<Result> RegisterResult(Result result)
        {
            var conn = _context.CreateConnection;
            //Return ultimate id created
            var sql = $"INSERT INTO Results (TakeExamId, State, AuditCreateDate) VALUES (@TakeExamId, @State, @AuditCreateDate) SELECT CAST (SCOPE_IDENTITY() AS INT)";
            var parameters = new DynamicParameters();
            parameters.Add("@TakeExamId", result.TakeExamId);
            parameters.Add("@State", 1);
            parameters.Add("@AuditCreateDate", DateTime.Now);

            var resultId = await conn.QueryFirstOrDefaultAsync<int>(sql, param: parameters);
            result.ResultId = resultId;

            return result;
        }

        public async Task RegisterResultDetail(ResultDetail result)
        {
            var conn = _context.CreateConnection;
            var sql = $"INSERT INTO ResultDetail (ResultId, ResultFile, TakeExamDetailId) VALUES (@ResultId, @ResultFile, @TakeExamDetailId)";
            var parameters = new DynamicParameters();
            parameters.Add("@ResultId", result.ResultId);
            parameters.Add("@ResultFile", result.ResultFile);
            parameters.Add("@TakeExamDetailId", result.TakeExamDetailId);

            await conn.ExecuteAsync(sql, param: parameters);
        }
        public async Task EditResult(Result result)
        {
            var conn = _context.CreateConnection;
            var sql = $"UPDATE Results SET TakeExamId = @TakeExamId WHERE ResultId = @ResultId";
            var parameters = new DynamicParameters();
            parameters.Add("@TakeExamId", result.TakeExamId);
            parameters.Add("@ResultId", result.ResultId);

            await conn.ExecuteAsync(sql, param: parameters);
        }

        public async Task EditResultDetail(ResultDetail result)
        {
            var conn = _context.CreateConnection;
            var sql = $"UPDATE ResultDetail " +
                $"SET ResultFile = @ResultFile, TakeExamDetailId = @TakeExamDetailId " +
                $"WHERE ResultDetailId = @ResultDetailId";
            var parameters = new DynamicParameters();
            parameters.Add("@ResultFile", result.ResultFile);
            parameters.Add("@TakeExamDetailId", result.TakeExamDetailId);
            parameters.Add("@ResultDetailId", result.ResultDetailId);

            await conn.ExecuteAsync(sql, param: parameters);
        }

        public async Task<ResultDetail> GetResultFile(int resultId, int resultDetailId)
        {
            var conn = _context.CreateConnection;
            var sql = $"SELECT ResultDetailId, ResultId, ResultFile, TakeExamDetailId FROM ResultDetail WHERE ResultId = @ResultId AND ResultDetailId = @ResultDetailId";
            var parameters = new DynamicParameters();
            parameters.Add("@ResultId", resultId);
            parameters.Add("@ResultDetailId", resultDetailId);

            var resultDetail = await conn.QuerySingleOrDefaultAsync<ResultDetail>(sql, param: parameters);
            return resultDetail;
        }
    }
}
