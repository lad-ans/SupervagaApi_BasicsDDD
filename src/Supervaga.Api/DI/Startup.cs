using System.Reflection;
using FluentValidation.AspNetCore;
using Microsoft.AspNetCore.ResponseCompression;
using Supervaga.Domain.Auth.DI;
using Supervaga.Domain.Filters;
using Supervaga.Domain.Shared.Notifications;
using Supervaga.Infra.DI;

namespace Supervaga.Api.DI
{
    /// <summary>
    /// </summary>
    public static class Startup
    {
        /// <summary>
        /// </summary>
        public static IServiceCollection Call(IServiceCollection services, IConfiguration configuration)
        {
            services.AddCors();

            // summary:
            //     Compressing Json Response
            services.AddResponseCompression(opt =>
            {
                opt.Providers.Add<GzipCompressionProvider>();
                opt.MimeTypes = ResponseCompressionDefaults.MimeTypes.Concat(new[] { "application/json" });
            });

            services.AddControllers(
                config =>
                {
                    config.Filters.Add<ValidationErrorFilter>();
                    config.Filters.Add<ErrorResultFilter>();
                }
            ).ConfigureApiBehaviorOptions(options =>
            {
                options.SuppressModelStateInvalidFilter = true;
            }).AddNewtonsoftJson(options =>
            {
                options.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore;
                options.SerializerSettings.NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore;
                options.SerializerSettings.DateTimeZoneHandling = Newtonsoft.Json.DateTimeZoneHandling.Local;
            }).AddFluentValidation(options =>
            {
                options.RegisterValidatorsFromAssembly(Assembly.GetExecutingAssembly());
            });

            // summary:
            //     Context
            DiDataContext.Call(services, configuration);

            // summary:
            //     Auth Scheme
            DiAuthScheme.Add(services);

            // summary:
            //     Core
            services.AddScoped<NotificationContext>();
            services.AddScoped<ValidationErrorFilter>();
            services.AddScoped<ErrorResultFilter>();

            DiAuth.Add(services);
            DiUser.Add(services);
            DiAd.Add(services);
            DiApplication.Add(services);
            DiDocument.Add(services);

            return services;
        }
    }
}