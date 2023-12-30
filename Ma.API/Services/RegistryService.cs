using AutoMapper;
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

    public RegistryService(IRepository<Registry> repository, IMapper mapper, ILogger<RegistryService> logger)
    {
        _repository = repository;
        _mapper = mapper;
        _logger = logger;
    }

    public ReadRegistryDto CreateRegistry(CreateRegistryDto createRegistryDto)
    {
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
        var readRegistryDto = _mapper.Map<ReadRegistryDto>(registryEntity);
        return readRegistryDto;
    }

    public ReadRegistryDto UpdateRegistry(int id, UpdateRegistryDto updateRegistryDto)
    {
        var registryEntity = _repository.Get(id);
        if (registryEntity is null)
        {
            throw new NotFoundEntityException($"Registry by id={id} cant be updated: Not Found.");
        }

        _mapper.Map(updateRegistryDto, registryEntity);
        _repository.Update(registryEntity);

        var readRegistryDtoUpdated = _mapper.Map<ReadRegistryDto>(registryEntity);

        return readRegistryDtoUpdated;

    }

    public void DeleteRegistry(int id)
    {
        var registry = _repository.Get(id);
        if (registry is null)
        {
            throw new NotFoundEntityException($"Registry by id={id} cant be deleted: Not Found.");
        }
        _repository.Delete(registry);
    }


}