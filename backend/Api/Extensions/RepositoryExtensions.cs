using Application.Ports.Outbound.Repositories;
using Infrastructure.Persistence.Adapters;
using Infrastructure.Persistence.Queries;
using Infrastructure.Persistence.Repositories;

namespace Api.Extensions;

public static class RepositoryExtensions
{
    public static IServiceCollection AddRepositories(
        this IServiceCollection services)
    {

        //USUARIOS
        services.AddScoped<UsuarioRepository>();
        services.AddScoped<UsuarioQueries>();
        services.AddScoped<UsuarioRepositoryPort, UsuarioRepositoryAdapter>();

        return services;
    }
}
