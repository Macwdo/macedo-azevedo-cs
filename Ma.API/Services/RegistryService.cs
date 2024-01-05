using AutoMapper;
using FluentValidation;
using Ma.API.Entities;
using Ma.API.Exceptions;
using Ma.API.Models.Registry;
using Ma.API.Repository;

namespace Ma.API.Services;

// TODO: Add Caching
// TODO: Add Logging
// TODO: Add Tests
public class RegistryService: IRegistryService
{
    private readonly IRepository<Registry> _repository;
    private readonly IMapper _mapper;
    private readonly ILogger<RegistryService> _logger;

    private readonly IValidator<CreateRegistryDto> _createRegistryDtoValidator;

    public RegistryService(IRepository<Registry> repository, IMapper mapper, ILogger<RegistryService> logger, IValidator<CreateRegistryDto> createRegistryDtoValidator)
    {
        _repository = repository;
        _mapper = mapper;
        _logger = logger;
        _createRegistryDtoValidator = createRegistryDtoValidator;
    }

    public ReadRegistryDto CreateRegistry(CreateRegistryDto createRegistryDto)
    {

        var result = _createRegistryDtoValidator.Validate(createRegistryDto);
        if (!result.IsValid)
        {
            throw new InvalidModelException(errors: result.Errors.Select(x => x.ErrorMessage));
        }

        var registryEntity = _mapper.Map<Registry>(createRegistryDto);
        _repository.Create(registryEntity);
        var readRegistryDto = _mapper.Map<ReadRegistryDto>(registryEntity);
        return readRegistryDto;
    }

    public IEnumerable<ReadRegistryDto> GetRegistries()
    {
        var registries = _repository.GetAllReadOnly();
        var readRegistriesDto = _mapper.Map<IEnumerable<ReadRegistryDto>>(registries);
        return readRegistriesDto;
    }

    public ReadRegistryDto? GetRegistry(int id)
    {
        var registryEntity = _repository.Get(id);
        return registryEntity is null ? null : _mapper.Map<ReadRegistryDto>(registryEntity);
    }

    public ReadRegistryDto UpdateRegistry(int id, UpdateRegistryDto updateRegistryDto)
    {
        var registry = _repository.Get(id);
        if (registry is null) throw new NotFoundEntityException(typeof(Registry), id);
        _mapper.Map(updateRegistryDto, registry);
        _repository.Update(registry);
        return _mapper.Map<ReadRegistryDto>(registry);
    }

    public void DeleteRegistry(int id)
    {
        var registry = _repository.Get(id);
        if (registry is not null)
            _repository.Delete(registry);
        else
            throw new NotFoundEntityException(typeof(Registry), id);
    }
}