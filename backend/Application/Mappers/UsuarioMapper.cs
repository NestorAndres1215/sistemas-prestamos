using System;
using System.Collections.Generic;
using System.Text;
using Application.DTOs.Auth;
using Application.Models;

namespace Application.Mappers;

public class UsuarioMapper
{

    public static UsuarioModel ToRegisterModel(RegisterUsuarioRequest request)
    {
        return new UsuarioModel
        {
            Username = request.Username,
            Email = request.Email,
            Password = request.Password
        };
    }
}
