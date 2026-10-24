using System.Security.Claims;
using Application.Common.Exceptions;
using Application.DTOs.Auth;
using Application.DTOs.Usuario;
using Application.Mappers;
using Application.Models;
using Application.Ports.Inbound;
using Application.Ports.Outbound;
using Application.Ports.Outbound.Repositories;
using Application.Validators;
using Domain.Constants;
using Domain.Entities;

namespace Application.Features.Auth.Services;

public class AuthService : AuthUseCase
{
    private readonly UsuarioRepositoryPort _repo;
    private readonly PasswordHasherPort _hasher;
    private readonly JwtTokenGeneratorPort _jwt;

    public AuthService(
        UsuarioRepositoryPort repo,
        PasswordHasherPort hasher,
        JwtTokenGeneratorPort jwt)
    {
        _repo = repo;
        _hasher = hasher;
        _jwt = jwt;
    }

    public async Task<UsuarioReponse?> GetCurrentUserFromClaims(
        ClaimsPrincipal user)
    {
        var id = AuthValidators.ValidateUserIdFromClaims(user);

        var usuario = await GetUserByIdAsync(id);

        return UsuarioMapper.ToResponse(usuario);
    }

    public async Task<AuthResponse> Login(LoginRequest dto)
    {
        var user = await GetUserByEmailAsync(dto.Email);

        var passwordValida = _hasher.Verify(
            dto.Password,
            user.Password);

        Console.WriteLine($"Hash presente: {!string.IsNullOrWhiteSpace(user.Password)}");
        Console.WriteLine($"Longitud del hash: {user.Password?.Length ?? 0}");
        Console.WriteLine($"Contraseña válida: {passwordValida}");

        if (!passwordValida)
        {
            throw new BadRequestException("Contraseña incorrecta.");
        }

        var token = _jwt.GenerateToken(user.Id, user.Email);

        return AuthMapper.ToResponse(user, token);
    }

    public async Task<UsuarioModel> UpdatePassword(int id, PasswordRequest dto)
    {
        var usuario = await GetUserByIdAsync(id);

        if (!_hasher.Verify(dto.PasswordActual, usuario.Password))
        {
            throw new UnauthorizedException("Credenciales inválidas.");
        }

        usuario.Password = _hasher.Hash(dto.PasswordNueva);

        return await _repo.UpdateAsync(usuario);
    }

    private async Task<UsuarioModel> GetUserByEmailAsync(string email)
    {
        return await _repo.GetByEmailAsync(email)
            ?? throw new NotFoundException("Correo no existe.");
    }

    private async Task<UsuarioModel> GetUserByIdAsync(int id)
    {
        return await _repo.GetByIdAsync(id)
            ?? throw new NotFoundException("Usuario no encontrado.");
    }

}
