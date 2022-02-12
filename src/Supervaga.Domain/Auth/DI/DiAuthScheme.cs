using System.Text;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;

namespace Supervaga.Domain.Auth.DI
{
    public static class DiAuthScheme
    {
        public static void Add(IServiceCollection services)
        {
            var key = Encoding.ASCII.GetBytes(Settings.Secret);
            var firebaseProjectRef = "https://securetoken.google.com/supervaga-8e8dc";

            services.AddAuthentication(
                options =>
                {
                    options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                    options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
                }
            ).AddJwtBearer(
                options =>
                {

                    options.RequireHttpsMetadata = false;
                    options.SaveToken = false;

                    // Firebase Authority
                    options.Authority = firebaseProjectRef;

                    options.TokenValidationParameters = new TokenValidationParameters
                    {
                        ValidateIssuer = false,
                        ValidateAudience = false,

                        // Firebase Validation Parameters
                        ValidIssuer = firebaseProjectRef,
                        ValidAudience = "supervaga-8e8dc",
                        ValidateLifetime = true,

                        // JWT Validation Parameters
                        ValidateIssuerSigningKey = true,
                        IssuerSigningKey = new SymmetricSecurityKey(key),
                    };

                }
            );
        }
    }
}