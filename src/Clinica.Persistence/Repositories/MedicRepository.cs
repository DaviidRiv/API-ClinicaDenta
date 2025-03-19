using Clinica.Application.Dtos.Medic.Reponse;
using Clinica.Application.Interface.Interfaces;
using Clinica.Domain.Entities;
using Clinica.Persistence.Context;
using Dapper;
using System.Data;

namespace Clinica.Persistence.Repositories
{
    public class MedicRepository : GenericRepository<Medic>, IMedicRepository
    {
        private readonly ApplicationDbContext _context;

        public MedicRepository(ApplicationDbContext context) : base(context)
        {
            _context = context;
        }

        public async Task<IEnumerable<GetAllMedicResponseDto>> GetAllMedics(string storedProcedure, object parameter)
        {
            using var conn = _context.CreateConnection;
            var objParam = new DynamicParameters(parameter);
            var medics = await conn.QueryAsync<GetAllMedicResponseDto>(storedProcedure, param: objParam, commandType: CommandType.StoredProcedure);
            return medics;
        }
    }
}
