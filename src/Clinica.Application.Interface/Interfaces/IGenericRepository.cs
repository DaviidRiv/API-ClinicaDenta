namespace Clinica.Application.Interface.Interfaces
{
    //Contiene todas las operaciones posibles a realizar, coordinada por una unidad de trabajo
    public interface IGenericRepository<T> where T : class
    {
        Task<IEnumerable<T>> GetAllAsync(string storedProcedure);
        Task<IEnumerable<T>> GetAllWithPagination(string storedProcedure, object parameter);

        Task<T> GetByIdAsync(string storedProcedure, object parameter);
        Task<bool> ExecAsync(string storedProcedurem, object parameters);

        Task<int> CountAsync(string tableName); //total de registros en la tabla
    }
}