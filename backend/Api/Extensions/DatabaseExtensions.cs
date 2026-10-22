using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace Api.Extensions;

public static class DatabaseExtensions
{
    public static IServiceCollection AddDatabase(
        this IServiceCollection services,
        IConfiguration configuration)
    {
        var connectionString = configuration
            .GetConnectionString("DefaultConnection")
            ?? throw new InvalidOperationException(
                "La cadena de conexión 'DefaultConnection' no está configurada.");

        services.AddDbContext<AppDbContext>(options =>
            options.UseMySQL(connectionString));

        return services;
    }
}
