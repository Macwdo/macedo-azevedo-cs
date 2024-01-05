using Ma.API.Exceptions;
using Ma.API.Models;
using Ma.API.Services;
using Microsoft.AspNetCore.Mvc;

namespace Ma.API.Controllers;

public class GenericCrudControlller<TEntity, TCreateDto, TReadDto, TUpdateDto> : ControllerBase
    where TEntity : class
    where TCreateDto : class
    where TReadDto : class
    where TUpdateDto : class
{

    protected readonly IGenericCrudService<TEntity, TCreateDto, TReadDto, TUpdateDto> service;
    public GenericCrudControlller(IGenericCrudService<TEntity, TCreateDto, TReadDto, TUpdateDto> service)
    {
        this.service = service;
    }
    
    [HttpGet]
    public IActionResult GetAll(int skip=1, int take = 10)
    {
        var entitiesDto = service.GetAllPaginated(skip, take).ToList();
        var paginationInfo = new PaginationInfo(skip, take, entitiesDto.Count());
        var paginationModel = new PaginationModel<TReadDto>(entitiesDto, paginationInfo);
        return Ok(paginationModel);
    }
    
    [HttpGet("{id}")]
    public IActionResult Get(int id)
    {
        var entityDto = service.Get(id);
        if (entityDto is null)
            return NotFound();
        return Ok(entityDto);
    }
    
    [HttpPost]
    public IActionResult Create(TCreateDto dto)
    {
        try
        {
            var entityDto = service.Create(dto);
            var id = GetIdFromEntityDto(entityDto);
            return CreatedAtAction(nameof(Get), new { id }, entityDto);

        }
        catch (NotFoundEntityException e)
        {
            return NotFound(e.Message);
        }
        catch (InvalidModelException e)
        {
            return BadRequest(e.Message);
        } catch (Exception e)
        {
            throw new ServerErrorException("Unexpected error trying to create entity");
        }
    }

    private int GetIdFromEntityDto(TReadDto entityDto)
    {
            var id = entityDto.GetType().GetProperty("Id")?.GetValue(entityDto, null);
            return (int)(id ?? throw new ServerErrorException("Unexpected error trying to get Id from entityDto"));
    }

    [HttpPut("{id}")]
    public IActionResult Update(int id, TUpdateDto dto)
    {
        try
        {
            var entityDto = service.Update(id, dto);
            return Ok(entityDto);
        }
        catch (NotFoundEntityException e)
        {
            return NotFound(e.Message);
        }
        catch (InvalidModelException e)
        {
            return BadRequest(e.Message);
        }
        catch (Exception e)
        {
            throw new ServerErrorException("Unexpected error trying to update entity");
        }
    }

    [HttpDelete("{id}")]
    public IActionResult Delete(int id)
    {
        try
        {
            service.Delete(id);
            return NoContent();
        }
        catch (NotFoundEntityException e)
        {
            return NotFound(e.Message);
        }
        catch (Exception e)
        {
            throw new ServerErrorException("Unexpected error trying to delete entity");
        }
    }
}