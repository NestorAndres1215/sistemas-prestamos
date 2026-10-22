
namespace Domain.Entities;

public class Usuario
{
    public int Id { get; set; }

    public required string Username { get; set; }

    public required string Email { get; set; }

    // Guardar el hash, nunca la contraseña original.
    public required string PasswordHash { get; set; }

    public string Rol { get; set; } = "ADMIN";

    public bool Activo { get; set; } = true;

    public DateTime FechaCreacion { get; set; } = DateTime.UtcNow;

    public DateTime? FechaActualizacion { get; set; }
}
