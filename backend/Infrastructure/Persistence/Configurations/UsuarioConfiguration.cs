
using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Persistence.Configurations;

public class UsuarioConfiguration : IEntityTypeConfiguration<UsuarioEntity>
{
    public void Configure(EntityTypeBuilder<UsuarioEntity> builder)
    {
        builder.ToTable("usuarios");

        // Clave primaria
        builder.HasKey(u => u.Id);

        builder.Property(u => u.Id)
            .HasColumnName("id")
            .ValueGeneratedOnAdd();

        // Nombre de usuario
        builder.Property(u => u.Username)
            .HasColumnName("username")
            .HasMaxLength(50)
            .IsRequired();

        builder.HasIndex(u => u.Username)
            .IsUnique();

        // Correo electrónico
        builder.Property(u => u.Email)
            .HasColumnName("email")
            .HasMaxLength(150)
            .IsRequired();

        builder.HasIndex(u => u.Email)
            .IsUnique();

        // Contraseña almacenada como hash
        builder.Property(u => u.Password)
            .HasColumnName("password_hash")
            .HasMaxLength(255)
            .IsRequired();

        // Estado de la cuenta
        builder.Property(u => u.Activo)
            .HasColumnName("activo")
            .HasDefaultValue(true)
            .IsRequired();

        // Fecha de creación
        builder.Property(u => u.FechaCreacion)
            .HasColumnName("fecha_creacion")
            .HasColumnType("datetime(6)")
            .HasDefaultValueSql("CURRENT_TIMESTAMP(6)")
            .IsRequired();

        // Fecha de actualización
        builder.Property(u => u.FechaActualizacion)
            .HasColumnName("fecha_actualizacion")
            .HasColumnType("datetime(6)")
            .IsRequired(false);
    }
}
