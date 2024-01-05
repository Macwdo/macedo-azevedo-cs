using AutoMapper;
using FluentValidation;
using Ma.API.Exceptions;
using Ma.API.Repository;
using Microsoft.AspNetCore.Mvc;

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
    private readonly ILogger<GenericCrudService<TEntity, TCreateDto, TReadDto, TUpdateDto>> _logger;

    private readonly IValidator<TCreateDto> _createValidator;
    private readonly IValidator<TUpdateDto> _updateValidator;
    private readonly IRepository<TEntity> _repository;
    
    public GenericCrudService(IMapper mapper, IRepository<TEntity> repository, ILogger<GenericCrudService<TEntity, TCreateDto, TReadDto, TUpdateDto>> logger, IValidator<TCreateDto> createValidator, IValidator<TUpdateDto> updateValidator)
    {
        _mapper = mapper;
        _repository = repository;
        _logger = logger;
        _createValidator = createValidator;
        _updateValidator = updateValidator;
    }

    [HttpPost]
    public TReadDto Create(TCreateDto createDto)
    {
        var validationResult = _createValidator.Validate(createDto);
        if (!validationResult.IsValid)
        {
            _logger.LogError("Error trying to create entity with invalid model");

            throw new InvalidModelException(validationResult.Errors.Select(e => e.ErrorMessage));
        }

        var entity = _mapper.Map<TEntity>(createDto);
        _repository.Create(entity);
        return _mapper.Map<TReadDto>(entity);
    }

    [HttpGet]
    public IEnumerable<TReadDto> GetAll()
    {
        var entities = _repository.GetAllReadOnly();
        return _mapper.Map<IEnumerable<TReadDto>>(entities);
    }

    public IEnumerable<TReadDto> GetAllPaginated(int skip, int take)
    {
        var entities = _repository.GetAllReadOnlyPaginated(skip, take);
        return _mapper.Map<IEnumerable<TReadDto>>(entities);
    }

    public TReadDto? Get(int id)
    {
        var entity = _repository.Get(id);
        return entity is null ? null : _mapper.Map<TReadDto>(entity);
    }

    public TReadDto Update(int id, TUpdateDto updateDto)
    {
        var validationResult = _updateValidator.Validate(updateDto);
        if (!validationResult.IsValid)
        {
            _logger.LogError("Error trying to update entity {id} with invalid model", id);
            throw new InvalidModelException(validationResult.Errors.Select(e => e.ErrorMessage));
        }


        var entity = _repository.Get(id);
        if (entity is null)
            throw new NotFoundEntityException(typeof(TEntity), id);

        _mapper.Map(updateDto, entity);
        _repository.Update(entity);
        return _mapper.Map<TReadDto>(entity);
    }

    public void Delete(int id)
    {
        var entity = _repository.Get(id);
        if (entity is null)
            throw new NotFoundEntityException(typeof(TEntity), id);

        _repository.Delete(entity);
    }
}