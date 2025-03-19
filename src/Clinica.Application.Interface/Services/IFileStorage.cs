using Microsoft.AspNetCore.Http;

namespace Clinica.Application.Interface.Services
{
    public interface IFileStorage
    {
        Task<string> SaveFile(string container, IFormFile file);
        Task<string> EditFile(string container, IFormFile file, string route);
        //Task<string> RemoveFile(string route, string container); //no necesario
    }
}
