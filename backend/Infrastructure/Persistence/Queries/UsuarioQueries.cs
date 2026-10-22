
using Application.DTOs.Common;
using Application.Models;
using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Persistence.Queries;

public class UsuarioQueries
{
    private readonly AppDbContext _context;

    public UsuarioQueries(AppDbContext context)
    {
        _context = context;
    }

    public async Task<PagedResult<UsuarioModel>> GetAllAsync(
        int page,
        int pageSize,
        string? search,
        string? estado)
    {
        if (page < 1)
        {
            throw new ArgumentOutOfRangeException(
                nameof(page), "La página debe ser mayor que cero.");
        }

        if (pageSize < 1)
        {
            throw new ArgumentOutOfRangeException(
                nameof(pageSize), "El tamaño debe ser mayor que cero.");
        }

        var query = _context.Usuarios.AsNoTracking();

        if (!string.IsNullOrWhiteSpace(search))
        {
            search = search.Trim();

            query = query.Where(u =>
                u.Username.Contains(search) ||
                u.Email.Contains(search));
        }

        if (!string.IsNullOrWhiteSpace(estado))
        {
            estado = estado.Trim();

            if (bool.TryParse(estado, out bool activo))
            {
                query = query.Where(u => u.Activo == activo);
            }
        }

        var total = await query.CountAsync();

        var items = await query
            .OrderBy(u => u.Id)
            .Skip((page - 1) * pageSize)
            .Take(pageSize)
            .Select(u => new UsuarioModel
            {
                Id = u.Id,
                Username = u.Username,
                Email = u.Email,
                Activo = u.Activo,
                FechaCreacion = u.FechaCreacion,
                FechaActualizacion = u.FechaActualizacion
            })
            .ToListAsync();

        return new PagedResult<UsuarioModel>
        {
            Items = items,
            TotalCount = total,
            Page = page,
            PageSize = pageSize
        };
    }
}
