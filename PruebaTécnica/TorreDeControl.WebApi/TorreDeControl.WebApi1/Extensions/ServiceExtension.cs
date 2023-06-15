using Microsoft.AspNetCore.Mvc;
using Microsoft.OpenApi.Models;

namespace TorreDeControl.WebApi.Extensions
{
    public static class ServiceExtension
    {
        public static void AddSwaggerExtension(this IServiceCollection services)
        {
            services.AddSwaggerGen(options =>
            {
                List<string> xmlFiles = Directory.GetFiles(AppContext.BaseDirectory, "*.xml", searchOption: SearchOption.TopDirectoryOnly).ToList();
                xmlFiles.ForEach(xmlFile => options.IncludeXmlComments(xmlFile));

                options.SwaggerDoc("v1", new OpenApiInfo
                {
                    Version = "v1",
                    Title = "TorreDeControl API",
                    Description = "Esta Api es una prueba de Backend",
                    Contact = new OpenApiContact
                    {
                        Name = "Rodrigo Soto Abreu",
                        Email = "sotoabreurodrigo@gmail.com",
                        Url = new Uri("https://github.com/IndioOtaku")
                    }
                });

            });
        }

        public static void AddApiVersioningExtension(this IServiceCollection services)
        {
            services.AddApiVersioning(config =>
            {
                config.DefaultApiVersion = new ApiVersion(1, 0);
                config.AssumeDefaultVersionWhenUnspecified = true;
                config.ReportApiVersions = true;
            });
        }
    }
}
