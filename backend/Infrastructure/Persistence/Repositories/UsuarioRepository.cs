
using Domain.Entities;
using Infrastructure.Data;

namespace Infrastructure.Persistence.Repositories;

public class UsuarioRepository
{
    private readonly AppDbContext _context;

    public UsuarioRepository(AppDbContext context)
    {
        _context = context;
    }


    public async Task<UsuarioEntity> AddAsync(
        UsuarioEntity usuario)
    {
        await _context.Usuarios.AddAsync(usuario);
        await _context.SaveChangesAsync();

        return usuario;
    }


}
