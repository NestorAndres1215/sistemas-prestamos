
using DotNetEnv;


using DotNetEnv;

Env.Load();

var builder = WebApplication.CreateBuilder(args);

// Registrar servicios
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Obtener la cadena de conexión desde el .env
var connectionString =
    $"Server={Env.GetString("DB_SERVER")};" +
    $"Port={Env.GetString("DB_PORT")};" +
    $"Database={Env.GetString("DB_NAME")};" +
    $"User={Env.GetString("DB_USER")};" +
    $"Password={Env.GetString("DB_PASSWORD")};";

var app = builder.Build();

// Configurar Swagger UI en desarrollo
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();

app.Run();
