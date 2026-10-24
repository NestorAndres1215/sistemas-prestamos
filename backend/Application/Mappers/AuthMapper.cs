
using Application.DTOs.Auth;
using Application.Models;

namespace Application.Mappers;

public static class AuthMapper
{
    public static AuthResponse ToResponse(
        UsuarioModel user,
        string token)
    {
        return new AuthResponse
        {
            Username = user.Username,
            Email = user.Email,
            Token = token
        };
    }
}
