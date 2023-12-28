using Ma.API.DTOs.Registry;

namespace Ma.API.Services;

public interface IRegistryService
{
    ReadRegistryDto CreateRegistry(CreateRegistryDto createRegistryDto);
    IEnumerable<ReadRegistryDto> GetRegistries();
    ReadRegistryDto? GetRegistry(int id);
    ReadRegistryDto UpdateRegistry(int id, UpdateRegistryDto updateRegistryDto);
    void DeleteRegistry(int id);
}