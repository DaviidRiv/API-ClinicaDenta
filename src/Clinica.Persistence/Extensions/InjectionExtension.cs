using Clinica.Application.Interface.Interfaces;
using Clinica.Persistence.Context;
using Clinica.Persistence.Repositories;
using Microsoft.Extensions.DependencyInjection;

namespace Clinica.Persistence.Extensions
{
    public static class InjectionExtension
    {
        public static IServiceCollection AddInjectionPersistence(this IServiceCollection services)
        {
            services.AddSingleton<ApplicationDbContext>();

            //Examen en Diferente que UnitOfWork. por la relacion
            //Patron de Diseño UnitOfWork y Repository
            services.AddScoped(typeof(IGenericRepository<>), typeof(GenericRepository<>));
            services.AddTransient<IUnitOfWork, UnitOfWork>();

            return services;
        }
    }
}
