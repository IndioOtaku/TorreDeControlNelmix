using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;
using TorreDeControl.Core.Application.Interfaces.IServices;
using TorreDeControl.Core.Application.Services;


namespace TorreDeControl.Core.Application
{
    //Extension Method - Decorator
    public static class ServiceRegistration
    {
        public static void AddApplicationLayer(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddAutoMapper(Assembly.GetExecutingAssembly());
            #region Services
            services.AddTransient(typeof(IGenericService<,,>), typeof(GenericService<,,>));
            services.AddTransient<IAeropuertoService, AeropuertoService>();
            services.AddTransient<IAviónService, AviónService>();
            services.AddTransient<IPasajeroService, PasajeroService>();
            #endregion
        }
    }
}