using Clinica.Application.Interface.Services;
using Clinica.Infraestructure.Authentication;
using Clinica.Infraestructure.Services;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Configuration;
using Clinica.Application.Interface.Authentication;
using Microsoft.AspNetCore.Authorization;

namespace Clinica.Infraestructure.Extensions
{
    public static class InjectionExtensions
    {
        public static IServiceCollection AddInjectionInfraestructure(this IServiceCollection services, ConfigurationManager configuration)
        {
            services.AddTransient<IFileStorage, FileStorage>();

            services.Configure<JwtSettings>(configuration.GetSection(JwtSettings.SectionName));
            services.AddSingleton<IJwtTokenGenerator, JwtTokenGenrator>();

            services.AddSingleton<IPermissionService, PermissionService>();
            services.AddSingleton<IAuthorizationHandler, PermissionAuthorizationHandler>();
            services.AddSingleton<IAuthorizationPolicyProvider, PermissionAuthorizationPolicyProvider>();

            return services;
        }
    }
}
