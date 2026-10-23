using System;
using System.Collections.Generic;
using System.Text;
using Application.DTOs.Usuario;
using Application.Models;

namespace Application.Mappers;

public class UsuarioMapper
{

    public static UsuarioModel ToRegisterModel(
        RegistroUsuarioRequest request,
        string passwordHash)
    {
        return new UsuarioModel
        {
            Username = request.Username,
            Email = request.Email,
            Password = passwordHash,
            Activo = true
        };
    }

    public static UsuarioReponse ToResponse(UsuarioModel model)
    {
        return new UsuarioReponse
        {
            Id = model.Id,
            UserName = model.Username,
            Email = model.Email,
            Estado = model.Activo ? "ACTIVO" : "INACTIVO"
        };
    }

}
