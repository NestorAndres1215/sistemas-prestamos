
using Application.DTOs.Common;
using Application.Models;
using Application.Ports.Outbound.Repositories;
using Infrastructure.Persistence.Mappers;
using Infrastructure.Persistence.Queries;
using Infrastructure.Persistence.Repositories;

namespace Infrastructure.Persistence.Adapters;

public class UsuarioRepositoryAdapter : UsuarioRepositoryPort
{
    private readonly UsuarioRepository _repository;
    private readonly UsuarioQueries _queries;

    public UsuarioRepositoryAdapter(
        UsuarioRepository repository,
        UsuarioQueries queries)
    {
        _repository = repository;
        _queries = queries;
    }

    public Task<PagedResult<UsuarioModel>> GetAllAsync(
           int page,
           int pageSize,
           string search,
           string estado)
    {
        return _queries.GetAllAsync(
            page,
            pageSize,
            search,
            estado);
    }

    public async Task<UsuarioModel?> GetByEmailAsync(string email)
    {
        var usuario = await _repository.GetByEmailAsync(email);

        return usuario is null
            ? null!
            : UsuarioMapperPersistence.ToModel(usuario);
    }

    public async Task<UsuarioModel?> GetByIdAsync(int id)
    {
        var usuario = await _repository.GetByIdAsync(id);

        return usuario is null
            ? null
            : UsuarioMapperPersistence.ToModel(usuario);
    }

    public async Task<UsuarioModel?> GetByUsernameAsync(string username)
    {
        var usuario = await _repository.GetByUsernameAsync(username);

        return usuario is null
            ? null
            : UsuarioMapperPersistence.ToModel(usuario);
    }

    public async Task<UsuarioModel> AddAsync(UsuarioModel usuario)
    {

        var entity = UsuarioMapperPersistence.ToEntity(usuario);

        var creado = await _repository.AddAsync(entity);

        return UsuarioMapperPersistence.ToModel(creado);
    }

    public async Task<UsuarioModel> UpdateAsync(UsuarioModel usuario)
    {
        var entity = UsuarioMapperPersistence.ToEntity(usuario);

        var actualizado = await _repository.UpdateAsync(entity);

        return UsuarioMapperPersistence.ToModel(actualizado);
    }

}
