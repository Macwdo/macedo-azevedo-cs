using Ma.API.Exceptions;
using Ma.API.Models.Registry;
using Ma.API.Services;
using Microsoft.AspNetCore.Mvc;

namespace Ma.API.Controllers.V1.Registry;

[ApiController]
[Route("api/v1/[controller]")]
public class RegistriesController: ControllerBase
{
    private readonly IRegistryService _registryService;

    public RegistriesController(IRegistryService registryService)
    {
        _registryService = registryService;
    }

    [HttpGet]
    [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(IEnumerable<ReadRegistryDto>))]
    [ProducesResponseType(StatusCodes.Status500InternalServerError, Type = typeof(ProblemDetails))]
    public IActionResult GetAll()
    {
        var registries = _registryService.GetRegistries();
        return Ok(registries);
    }

    [HttpGet("{id:int}")]
    [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(ReadRegistryDto))]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError, Type = typeof(ProblemDetails))]
    public IActionResult Get(int id)
    {
        var registry = _registryService.GetRegistry(id);
        if (registry is null)
            return NotFound();

        return Ok(registry);
    }

    [HttpPost]
    [ProducesResponseType(StatusCodes.Status201Created, Type = typeof(ReadRegistryDto))]
    [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(ValidationProblemDetails))]
    [ProducesResponseType(StatusCodes.Status500InternalServerError, Type = typeof(ProblemDetails))]
    public IActionResult Create([FromBody] CreateRegistryDto createRegistryDto){
        var readRegistryDto = _registryService.CreateRegistry(createRegistryDto);

        return CreatedAtAction(nameof(Get), new {id = readRegistryDto.Id}, readRegistryDto);
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
    }

    [HttpDelete("{id:int}")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError, Type = typeof(ProblemDetails))]
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

    }
}