using Application.Models;

namespace Application.Ports.Outbound.Repositories;

public interface UsuarioRepositoryPort
{
    
    Task<UsuarioModel?> GetByIdAsync(int id);
    Task<UsuarioModel?> GetByEmailAsync(string email);
    Task<UsuarioModel?> GetByUsernameAsync(string username);
    Task<UsuarioModel> AddAsync(UsuarioModel usuario);
    Task<UsuarioModel> UpdateAsync(UsuarioModel usuario);

}
