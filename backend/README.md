
# Sistema de Préstamos

API REST para administrar préstamos de dinero, clientes,
cuotas, pagos y usuarios.

## Tecnologías

- C#
- ASP.NET Core Web API
- MySQL
- Entity Framework Core
- JWT Bearer
- Arquitectura hexagonal

## Arquitectura

- Domain: entidades y reglas del negocio.
- Application: DTOs, puertos, casos de uso y mappers.
- Infrastructure: persistencia, repositorios y seguridad.
- Api: controladores y configuración HTTP.

## Requisitos

- SDK de .NET compatible con el proyecto.
- MySQL Server.
- Git.

## Configuración

1. Clonar el repositorio.
2. Configurar la conexión a MySQL.
3. Configurar las opciones JWT.
4. Restaurar los paquetes NuGet.
5. Ejecutar las migraciones.
6. Iniciar la API.

## Ejecución

Desde la raíz de la solución:

```bash
dotnet restore
dotnet build
dotnet run --project Api/Api.csproj
```

Consulta la URL de ejecución en la salida de la consola
o en Api/Properties/launchSettings.json.
