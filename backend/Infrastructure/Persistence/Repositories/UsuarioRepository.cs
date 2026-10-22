
using Domain.Entities;
using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Persistence.Repositories;

public class UsuarioRepository
{
    private readonly AppDbContext _context;

    public UsuarioRepository(AppDbContext context)
    {
        _context = context;
    }

    public async Task<UsuarioEntity?> GetByIdAsync(int id)
    {
        return await _context.Usuarios
            .AsNoTracking()
            .SingleOrDefaultAsync(u => u.Id == id);
    }

    public async Task<UsuarioEntity?> GetByEmailAsync(string email)
    {
        return await _context.Usuarios
            .SingleOrDefaultAsync(u => u.Email == email);
    }

    public async Task<UsuarioEntity?> GetByUsernameAsync(
        string username)
    {
        return await _context.Usuarios
            .SingleOrDefaultAsync(u => u.Username == username);
    }

    public async Task<UsuarioEntity> AddAsync(
        UsuarioEntity usuario)
    {
        await _context.Usuarios.AddAsync(usuario);
        await _context.SaveChangesAsync();

        return usuario;
    }

    public async Task<UsuarioEntity?> UpdateAsync(
        UsuarioEntity usuario)
    {
        var existente = await _context.Usuarios
            .SingleOrDefaultAsync(u => u.Id == usuario.Id);

        if (existente is null)
        {
            return null;
        }

        existente.Username = usuario.Username;
        existente.Email = usuario.Email;
        existente.Password = usuario.Password;
        existente.Activo = usuario.Activo;
        existente.FechaActualizacion = DateTime.UtcNow;

        await _context.SaveChangesAsync();

        return existente;
    }
}
