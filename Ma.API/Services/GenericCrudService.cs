using AutoMapper;
using Ma.API.Entities;
using Ma.API.Exceptions;
using Ma.API.Repository;

namespace Ma.API.Services;

// Todo: Test and use
public class GenericCrudService<TEntity, TCreateDto, TReadDto, TUpdateDto> :
    IGenericCrudService<TEntity, TCreateDto, TReadDto, TUpdateDto>
    where TEntity : class
    where TCreateDto : class
    where TReadDto : class
    where TUpdateDto : class
{
    private readonly IMapper _mapper;
    
    private readonly IRepository<TEntity> _repository;
    
    public GenericCrudService(IMapper mapper, IRepository<TEntity> repository)
    {
        _mapper = mapper;
        _repository = repository;
    }
    public TReadDto Create(TCreateDto createDto)
    {
        var entity = _mapper.Map<TEntity>(createDto);
        _repository.Create(entity);
        return _mapper.Map<TReadDto>(entity);
    }

    public IEnumerable<TReadDto> GetAll()
    {
        var entities = _repository.GetAllReadOnly();
        return _mapper.Map<IEnumerable<TReadDto>>(entities);
    }

    public TReadDto? Get(int id)
    {
        var entity = _repository.Get(id);
        return entity is null ? null : _mapper.Map<TReadDto>(entity);
    }

    public TReadDto Update(int id, TUpdateDto updateDto)
    {
        var entity = _repository.Get(id);
        if (entity is null)
            throw new NotFoundException($"{entity} with id {id} not found. Cannot update entity with id {id}");

        _mapper.Map(updateDto, entity);
        _repository.Update(entity);
        return _mapper.Map<TReadDto>(entity);
    }

    public void Delete(int id)
    {
        var entity = _repository.Get(id);
        if (entity is null)
            throw new NotFoundException($"{entity} with id {id} not found. Cannot delete entity with id {id}");

        _repository.Delete(entity);
    }
}