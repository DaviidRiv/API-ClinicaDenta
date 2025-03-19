using Clinica.Application.Interface.Interfaces;
using Clinica.Domain.Entities;
using Clinica.Persistence.Context;
using Dapper;
using System.Data;

namespace Clinica.Persistence.Repositories
{
    public class UserRepository : GenericRepository<User>, IUserRepository
    {
        private readonly ApplicationDbContext _context;

        public UserRepository(ApplicationDbContext context) : base(context)
        {
            _context = context;
        }

        public async Task<User> GetUserByEmailAsync(string sp, string email)
        {
            using var conn = _context.CreateConnection;
            var parameters = new DynamicParameters();
            parameters.Add("@Email", email);

            var user = await conn.QuerySingleOrDefaultAsync<User>(sp, param: parameters, commandType: CommandType.StoredProcedure);
            return user;
        }
    }
}
