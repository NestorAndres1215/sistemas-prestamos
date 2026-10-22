using System;
using System.Collections.Generic;
using System.Security.Claims;
using System.Text;
using Application.DTOs.Auth;
using Domain.Entities;

namespace Application.Ports.Inbound;

public interface IAuthService
{
    Task<UsuarioEntity> Register(RegisterUsuarioRequest dto);
    Task<UsuarioEntity> UpdatePassword(int id, PasswordRequest dto);
    Task<AuthResponse> Login(LoginRequest dto);

}
