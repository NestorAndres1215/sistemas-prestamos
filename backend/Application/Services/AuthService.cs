using System.Security.Claims;
using Application.DTOs.Auth;
using Application.DTOs.Usuario;
using Application.Ports.Inbound;
using Application.Ports.Outbound;
using Domain.Entities;

namespace Application.Features.Auth.Services;

public class AuthService : AuthUseCase
{
    private readonly IUsuarioRepository _repo;
    private readonly IPasswordHasher _hasher;
    private readonly IJwtTokenGenerator _jwt;

    public AuthService(
        IUsuarioRepository repo,
        IPasswordHasher hasher,
        IJwtTokenGenerator jwt)
    {
        _repo = repo;
        _hasher = hasher;
        _jwt = jwt;
    }

    public Task<UsuarioReponse?> GetCurrentUserFromClaims(ClaimsPrincipal user)
    {
        throw new NotImplementedException();
    }

    public Task<AuthResponse> Login(LoginRequest dto)
    {
        throw new NotImplementedException();
    }

    public Task<UsuarioEntity> Register(RegistroUsuarioRequest dto)
    {
        throw new NotImplementedException();
    }

    public Task<UsuarioEntity> UpdatePassword(int id, PasswordRequest dto)
    {
        throw new NotImplementedException();
    }

}
