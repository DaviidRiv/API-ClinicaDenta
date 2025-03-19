using Clinica.Domain.Entities;

namespace Clinica.Application.Interface.Interfaces
{
    public interface IUserRepository : IGenericRepository<User>
    {
        Task<User> GetUserByEmailAsync(string sp, string email);
    }
}
