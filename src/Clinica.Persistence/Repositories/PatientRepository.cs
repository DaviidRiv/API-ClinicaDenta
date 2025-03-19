using Clinica.Application.Dtos.Patient.Reponse;
using Clinica.Application.Interface.Interfaces;
using Clinica.Domain.Entities;
using Clinica.Persistence.Context;
using Dapper;
using System.Data;

namespace Clinica.Persistence.Repositories
{
    public class PatientRepository : GenericRepository<Patient>, IPatientRepository
    {
        private readonly ApplicationDbContext _context;

        public PatientRepository(ApplicationDbContext context) : base(context)
        {
            _context = context;
        }

        public async Task<IEnumerable<GetAllPatientResponseDto>> GetAllPatients(string storedProcedure, object parameter)
        {
            using var conn = _context.CreateConnection;
            var objParam = new DynamicParameters(parameter);
            var patients = await conn.QueryAsync<GetAllPatientResponseDto>(storedProcedure, param: objParam ,commandType: CommandType.StoredProcedure);
            return patients;
        }
    }
}
