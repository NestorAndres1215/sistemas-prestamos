namespace Domain.Entities;

public class UsuarioEntity
{
    public int Id { get; set; }

    public required string Username { get; set; }

    public required string Email { get; set; }

    public required string Password { get; set; }

    public bool Activo { get; set; } = true;

    public DateTime FechaCreacion { get; set; } = DateTime.UtcNow;

    public DateTime? FechaActualizacion { get; set; }
}
