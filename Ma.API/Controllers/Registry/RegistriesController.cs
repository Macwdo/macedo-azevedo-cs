using Ma.API.DTOs.Registry;
using Ma.API.Exceptions;
using Ma.API.Services;
using Microsoft.AspNetCore.Mvc;

namespace Ma.API.Controllers.Registry;

[ApiController]
[Route("[controller]")]
public class RegistriesController: ControllerBase
{
    private readonly RegistryService _registryService;

    private ObjectResult InternalError => Problem($"Internal Error", null, StatusCodes.Status502BadGateway, "ERROR");

    public RegistriesController(RegistryService registryService)
    {
        _registryService = registryService;
    }

    [HttpGet]
    public IActionResult GetAll()
    {
        var registries = _registryService.GetRegistries();
        return Ok(registries);
    }

    [HttpGet("{id:int}")]
    public IActionResult Get(int id)
    {
        var registry = _registryService.GetRegistry(id);
        if (registry is null)
            return NotFound();

        return Ok(registry);
    }

    [HttpPost]
    public IActionResult Create([FromBody] CreateRegistryDto createRegistryDto){
        try
        {
            var readRegistryDto = _registryService.CreateRegistry(createRegistryDto);

            return CreatedAtAction(nameof(Get), new {id = readRegistryDto.Id}, readRegistryDto);
        }
        catch (Exception)
        {
            return InternalError;
        }
    }

    [HttpPut("{id:int}")]
    public IActionResult Put(int id, [FromBody] UpdateRegistryDto updateRegistryDto)
    {
        try
        {
            var readRegistryDto = _registryService.UpdateRegistry(id, updateRegistryDto);
            return Ok(readRegistryDto);
        }
        catch (NotFoundEntityException)
        {
            return NotFound($"Error: Registry by id={id} not found.");
        }
        catch (Exception)
        {
            return InternalError;
        }
    }

    [HttpDelete("{id:int}")]
    public IActionResult Delete(int id)
    {
        try
        {
            _registryService.DeleteRegistry(id);
            return NoContent();
        }
        catch (NotFoundEntityException)
        {
            return NotFound($"Error: Registry by id={id} not found.");
        }
        catch (Exception)
        {
            return InternalError;
        }
    }
}