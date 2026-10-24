
using Application.Ports.Outbound;
using Infrastructure.Auth;

namespace Api.Extensions;

public static class InfrastructureExtensions
{
    public static IServiceCollection AddInfrastructureServices(
        this IServiceCollection services)
    {
        services.AddScoped<PasswordHasherPort, PasswordHasher>();

        services.AddScoped<JwtTokenGeneratorPort, JwtTokenGenerator>();

        return services;
    }
}
