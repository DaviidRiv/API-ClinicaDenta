using Clinica.Application.Dtos.Result.Response;
using Clinica.Domain.Entities;

namespace Clinica.Application.Interface.Interfaces
{
    public interface IResultRepository : IGenericRepository<Result>
    {
        Task<IEnumerable<GetAllResultResponseDto>> GetAllResults(string sp, object parameters);
        Task<Result> GetResultById(int resultId);
        Task<IEnumerable<ResultDetail>> GetResultDetailByResultId(int resultId);
        Task<Result> RegisterResult(Result result);
        Task EditResult(Result result);
        Task EditResultDetail(ResultDetail result);
        Task <ResultDetail> GetResultFile(int resultId, int resultDetailId); //Encontrar archivos en lista
        Task RegisterResultDetail(ResultDetail result);
    }
}
