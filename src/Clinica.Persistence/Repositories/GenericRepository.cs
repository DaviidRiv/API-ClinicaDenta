using Clinica.Application.Interface.Interfaces;
using Clinica.Persistence.Context;
using Dapper;
using System.Data;

namespace Clinica.Persistence.Repositories
{
    public class GenericRepository<T> : IGenericRepository<T> where T : class
    {
        private readonly ApplicationDbContext _context;

        public GenericRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<T>> GetAllAsync(string storedProcedure)
        {
            using var conn = _context.CreateConnection;

            return await conn.QueryAsync<T>(storedProcedure, commandType: CommandType.StoredProcedure);
        }

        public async Task<T> GetByIdAsync(string storedProcedure, object parameter)
        {
            using var conn = _context.CreateConnection;
            var objParam = new DynamicParameters(parameter);

            return await conn.QuerySingleOrDefaultAsync<T>(storedProcedure, param: objParam, commandType: CommandType.StoredProcedure);
        }

        public async Task<bool> ExecAsync(string storedProcedure, object parameters)
        {
            using var conn = _context.CreateConnection;
            var objParam = new DynamicParameters(parameters);
            var recordAffected = await conn.ExecuteAsync(storedProcedure, param: objParam, commandType: CommandType.StoredProcedure);
            return recordAffected > 0;
        }

        public async Task<IEnumerable<T>> GetAllWithPagination(string storedProcedure, object parameter)
        {
            using var conn = _context.CreateConnection;
            var objParam = new DynamicParameters(parameter);
            return await conn.QueryAsync<T>(storedProcedure, param: objParam, commandType: CommandType.StoredProcedure);
        }

        public async Task<int> CountAsync(string tableName)
        {
            using var conn = _context.CreateConnection;
            var query = $"SELECT COUNT(1) FROM {tableName}";
            var count = await conn.ExecuteScalarAsync<int>(query, commandType: CommandType.Text);
            return count;
        }
    }
}