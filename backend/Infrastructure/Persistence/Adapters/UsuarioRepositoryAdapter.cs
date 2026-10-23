
using Application.DTOs.Common;
using Application.Models;
using Application.Ports.Outbound;
using Infrastructure.Persistence.Mappers;
using Infrastructure.Persistence.Queries;
using Infrastructure.Persistence.Repositories;

namespace Infrastructure.Persistence.Adapters;

public class UsuarioRepositoryAdapter : IUsuarioRepository
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

    /*

    public Task<PagedResult<UsuarioModel>> GetAllAsync(
        int page,
        int pageSize,
        string? search,
        string? estado)
    {
        return _queries.GetAllAsync(
            page,
            pageSize,
            search,
            estado);
    }*/

    public async Task<UsuarioModel> AddAsync(UsuarioModel usuario)
    {
        
        var entity = UsuarioMapperPersistence.ToEntity(usuario);

        var creado = await _repository.AddAsync(entity);

        return UsuarioMapperPersistence.ToModel(creado);
    }


}
