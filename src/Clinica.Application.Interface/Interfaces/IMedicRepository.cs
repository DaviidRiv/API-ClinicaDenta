using Clinica.Application.Dtos.Medic.Reponse;
using Clinica.Domain.Entities;

namespace Clinica.Application.Interface.Interfaces
{
    public interface IMedicRepository : IGenericRepository<Medic>
    {
        Task<IEnumerable<GetAllMedicResponseDto>> GetAllMedics(string storedProcedure, object parameter);
    }
}