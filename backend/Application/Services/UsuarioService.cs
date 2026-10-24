using System;
using System.Collections.Generic;
using System.Text;
using Application.DTOs.Common;
using Application.DTOs.Usuario;
using Application.Mappers;
using Application.Models;
using Application.Ports.Inbound;
using Application.Ports.Outbound;
using Application.Ports.Outbound.Repositories;
using Application.Validators;

namespace Application.Services;

public class UsuarioService : UsuarioUseCase
{
    private readonly UsuarioRepositoryPort _repo;
    private readonly PasswordHasherPort _hasher;
    private readonly JwtTokenGeneratorPort _jwt;

    public UsuarioService(
       UsuarioRepositoryPort repo,
       PasswordHasherPort hasher,
       JwtTokenGeneratorPort jwt)
    {
        _repo = repo;
        _hasher = hasher;
        _jwt = jwt;
    }

    public async Task<UsuarioReponse> Register(RegistroUsuarioRequest request)
    {
        UsuarioValidators.ValidateRegister(request);

        var passwordHash = _hasher.Hash(request.Password);

        var usuario = UsuarioMapper.ToRegisterModel(request, passwordHash);

        var usuarioRegistrado = await _repo.AddAsync(usuario);

        Console.WriteLine("=== USUARIO REGISTRADO ===");
        Console.WriteLine($"Id: {usuarioRegistrado.Id}");
        Console.WriteLine($"Username: {usuarioRegistrado.Username}");
        Console.WriteLine($"Email: {usuarioRegistrado.Email}");
        Console.WriteLine($"Password presente: {!string.IsNullOrWhiteSpace(usuarioRegistrado.Password)}");
        Console.WriteLine($"Longitud del hash: {usuarioRegistrado.Password?.Length ?? 0}");
        Console.WriteLine("==========================");

        return UsuarioMapper.ToResponse(usuarioRegistrado);
    }
}
