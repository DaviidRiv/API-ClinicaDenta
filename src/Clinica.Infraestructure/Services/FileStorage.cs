using Clinica.Application.Interface.Services;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;

namespace Clinica.Infraestructure.Services
{
    public class FileStorage : IFileStorage
    {
        //Entorno de la aplicacion, route raiz
        private readonly IWebHostEnvironment _env;
        //Solicitudes http, detalles del esquema y host
        private readonly IHttpContextAccessor _accessor;

        public FileStorage(IWebHostEnvironment env, IHttpContextAccessor accessor)
        {
            _env = env;
            _accessor = accessor;
        }

        public async Task<string> SaveFile(string container, IFormFile file)
        {
            //Ruta raiz de la aplicacion
            var wwwrootPath = _env.WebRootPath;
            var scheme = _accessor.HttpContext!.Request.Scheme;
            var host = _accessor.HttpContext!.Request.Host;

            return await SaveFileAsync(container, file, wwwrootPath, scheme, host.Value);
        }

        private async Task<string> SaveFileAsync(string container, IFormFile file, string wwwrootPath, string scheme, string host)
        {
            var extension = Path.GetExtension(file.FileName);
            var fileName = $"{Guid.NewGuid()}{extension}"; //nombre unico
            var folder = Path.Combine(wwwrootPath, container); //folder donde se guardara el archivo
            if (!Directory.Exists(folder))
            {
                Directory.CreateDirectory(folder);
            }

            //ruta completa
            string path = Path.Combine(folder, fileName);

            using (var memoryString = new MemoryStream())
            {
                await file.CopyToAsync(memoryString);
                var content = memoryString.ToArray();
                await File.WriteAllBytesAsync(path, content);
            }

            var url = $"{scheme}://{host}";
            var pathDB = Path.Combine(url, container, fileName).Replace("\\", "/");

            return pathDB;
        }

        public async Task<string> EditFile(string container, IFormFile file, string route)
        {
            //Ruta raiz de la aplicacion
            var wwwrootPath = _env.WebRootPath;
            var scheme = _accessor.HttpContext!.Request.Scheme;
            var host = _accessor.HttpContext!.Request.Host;

            return await EditFileAsync(container, file, route, wwwrootPath, scheme, host.Value);
        }

        private async Task<string> EditFileAsync(string container, IFormFile file, string route, string wwwrootPath, string scheme, string host)
        {
            await RemoveFileAsync(route, container, wwwrootPath);

            return await SaveFileAsync(container, file, wwwrootPath, scheme, host);
        }

        private Task RemoveFileAsync(string route, string container, string wwwrootPath)
        {
            if (string.IsNullOrEmpty(route))
            {
                return Task.CompletedTask;
            }

            var fileName = Path.GetFileName(route);
            var directoryFile = Path.Combine(wwwrootPath, container, fileName);

            if (File.Exists(directoryFile))
            {
                File.Delete(directoryFile);
            }

            return Task.CompletedTask;
        }

    }
}
