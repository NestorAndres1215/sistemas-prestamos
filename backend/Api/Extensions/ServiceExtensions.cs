
using Application.Features.Auth.Services;
using Application.Ports.Inbound;
using Application.Services;

namespace Api.Extensions;

public static class ServiceExtensions
{
    public static IServiceCollection AddApplicationServices(
        this IServiceCollection services)
    {
        services.AddScoped<AuthUseCase, AuthService>();
        services.AddScoped<UsuarioUseCase, UsuarioService>();

        return services;
    }
}
