using Clinica.Application.Dtos.Patient.Reponse;
using Clinica.Domain.Entities;

namespace Clinica.Application.Interface.Interfaces
{
    public interface IPatientRepository : IGenericRepository<Patient>
    {
        Task<IEnumerable<GetAllPatientResponseDto>> GetAllPatients(string storedProcedure, object parameter);
    }
}
