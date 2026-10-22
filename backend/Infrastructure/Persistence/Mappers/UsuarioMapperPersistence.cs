
using Application.Models;
using Domain.Entities;

namespace Infrastructure.Persistence.Mappers;

internal static class UsuarioMapperPersistence
{
    public static UsuarioModel ToModel(UsuarioEntity entity)
    {
        return new UsuarioModel
        {
            Id = entity.Id,
            Username = entity.Username,
            Email = entity.Email,
            Activo = entity.Activo,
            FechaCreacion = entity.FechaCreacion,
            FechaActualizacion = entity.FechaActualizacion
        };
    }

    public static UsuarioEntity ToEntity(UsuarioModel model)
    {
        return new UsuarioEntity
        {
            Id = model.Id,
            Username = model.Username ?? string.Empty,
            Email = model.Email ?? string.Empty,
            Password = model.Password ?? string.Empty,
            Activo = model.Activo,
            FechaCreacion = model.FechaCreacion,
            FechaActualizacion = model.FechaActualizacion
        };
    }
}
