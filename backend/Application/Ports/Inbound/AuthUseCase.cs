using System;
using System.Collections.Generic;
using System.Security.Claims;
using System.Text;
using Application.DTOs.Auth;
using Application.DTOs.Usuario;
using Domain.Entities;

namespace Application.Ports.Inbound;

public interface AuthUseCase
{

    Task<UsuarioReponse?> GetCurrentUserFromClaims(ClaimsPrincipal user);
    Task<UsuarioEntity> Register(RegistroUsuarioRequest dto);
    Task<UsuarioEntity> UpdatePassword(int id, PasswordRequest dto);
    Task<AuthResponse> Login(LoginRequest dto);

}
