
using Infrastructure.Auth;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System.Text;

namespace Api.Extensions;

public static class AuthenticationExtensions
{
    public static IServiceCollection AddJwtAuthentication(
        this IServiceCollection services,
        IConfiguration configuration)
    {
        var config = configuration.GetSection("JwtSettings");

        var issuer = config["Issuer"];
        var audience = config["Audience"];
        var key = config["Key"];

        if (string.IsNullOrWhiteSpace(issuer))
        {
            throw new InvalidOperationException(
                "No se encontró JwtSettings:Issuer en la configuración.");
        }

        if (string.IsNullOrWhiteSpace(audience))
        {
            throw new InvalidOperationException(
                "No se encontró JwtSettings:Audience en la configuración.");
        }

        if (string.IsNullOrWhiteSpace(key))
        {
            throw new InvalidOperationException(
                "No se encontró JwtSettings:Key en la configuración.");
        }

        if (Encoding.UTF8.GetByteCount(key) < 32)
        {
            throw new InvalidOperationException(
                "JwtSettings:Key debe tener al menos 32 bytes para HS256.");
        }

        services.Configure<JwtSettings>(
            configuration.GetSection("JwtSettings"));

        services
            .AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
            .AddJwtBearer(options =>
            {
                options.TokenValidationParameters =
                    new TokenValidationParameters
                    {
                        ValidateIssuer = true,
                        ValidIssuer = issuer,

                        ValidateAudience = true,
                        ValidAudience = audience,

                        ValidateLifetime = true,

                        ValidateIssuerSigningKey = true,
                        IssuerSigningKey = new SymmetricSecurityKey(
                            Encoding.UTF8.GetBytes(key)),

                        ClockSkew = TimeSpan.Zero
                    };

                options.Events = new JwtBearerEvents
                {
                    OnChallenge = async context =>
                    {
                        context.HandleResponse();

                        context.Response.StatusCode =
                            StatusCodes.Status401Unauthorized;

                        context.Response.ContentType =
                            "application/json";

                        await context.Response.WriteAsJsonAsync(new
                        {
                            status = 401,
                            message =
                                "No autenticado. Token faltante o inválido.",
                            type = "Unauthorized"
                        });
                    },

                    OnForbidden = async context =>
                    {
                        context.Response.StatusCode =
                            StatusCodes.Status403Forbidden;

                        context.Response.ContentType =
                            "application/json";

                        await context.Response.WriteAsJsonAsync(new
                        {
                            status = 403,
                            message =
                                "No tienes permisos para acceder a este recurso.",
                            type = "Forbidden"
                        });
                    }
                };
            });

        return services;
    }
}
