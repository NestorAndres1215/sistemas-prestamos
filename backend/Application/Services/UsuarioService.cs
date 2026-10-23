using System;
using System.Collections.Generic;
using System.Text;
using Application.DTOs.Common;
using Application.DTOs.Usuario;
using Application.Mappers;
using Application.Models;
using Application.Ports.Inbound;
using Application.Ports.Outbound;
using Application.Validators;

namespace Application.Services;

public class UsuarioService : UsuarioUseCase
{
    private readonly IUsuarioRepository _repo;
    private readonly IPasswordHasher _hasher;
    private readonly IJwtTokenGenerator _jwt;

    public UsuarioService(
       IUsuarioRepository repo,
       IPasswordHasher hasher,
       IJwtTokenGenerator jwt)
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

        return UsuarioMapper.ToResponse(usuarioRegistrado);
    }
}
