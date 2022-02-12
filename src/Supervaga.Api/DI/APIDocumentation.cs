using System.Reflection;
using Microsoft.OpenApi.Models;

namespace Supervaga.Api.DI
{
    /// <summary></summary>
    public static class APIDocumentation
    {
        /// <summary></summary>
        public static IServiceCollection Add(IServiceCollection services)
        {
            services.AddSwaggerGen(
            swagger =>
            {
                swagger.SwaggerDoc("v1", new OpenApiInfo
                {
                    Version = "v1",
                    Title = "Super Vaga API",
                    Description = "API de Criação, Candidatura e Despacho de Vagas",
                    TermsOfService = new Uri("https://drive.google.com/file/d/1mJvDelqfSx-LqWlKfILAFAj-DGf1_YlD/view?usp=sharing"),
                    Contact = new OpenApiContact
                    {
                        Name = "Ladino Anselmo",
                        Email = "ladino.anselmo@gmail.com",
                        Url = new Uri("https://github.com/layndev")
                    },
                    License = new OpenApiLicense
                    {
                        Name = "Open Source",
                        Url = new Uri("https://opensource.com")
                    }
                });
                var swaggerXML = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
                var xmlPath = Path.Combine(AppContext.BaseDirectory, swaggerXML);
                swagger.IncludeXmlComments(xmlPath);
            });

            return services;
        }
    }
}

