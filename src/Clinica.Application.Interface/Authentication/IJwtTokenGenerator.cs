using Clinica.Domain.Entities;

namespace Clinica.Application.Interface.Authentication
{
    public interface IJwtTokenGenerator
    {
        string GenerateToken(User user);
    }
}
