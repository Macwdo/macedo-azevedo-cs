namespace Ma.API.Services;

public interface IGenericCrudService<TEntity, TCreateDto, TReadDto, TUpdateDto>
{
    TReadDto Create(TCreateDto createDto);
    IEnumerable<TReadDto> GetAll();
    TReadDto? Get(int id);
    TReadDto Update(int id, TUpdateDto updateDto);
    void Delete(int id);
}