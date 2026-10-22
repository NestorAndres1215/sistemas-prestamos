using System;
using System.Collections.Generic;
using System.Text;
using Application.DTOs.Common;
using Application.Models;
using Domain.Entities;

namespace Application.Ports.Outbound;

public interface IUsuarioRepository
{
    Task<UsuarioModel?> GetByIdAsync(int id);

    Task<UsuarioModel?> GetByEmailAsync(string email);

    Task<UsuarioModel?> GetByUsernameAsync(string username);

    Task<PagedResult<UsuarioModel>> GetAllAsync(
        int page,
        int pageSize,
        string? search,
        string? estado);

    Task<UsuarioModel> AddAsync(UsuarioModel usuario);

    Task<UsuarioModel?> UpdateAsync(UsuarioModel usuario);

}
