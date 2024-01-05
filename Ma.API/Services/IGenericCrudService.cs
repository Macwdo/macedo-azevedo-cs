namespace Ma.API.Services;

public interface IGenericCrudService<TEntity, TCreateDto, TReadDto, TUpdateDto>
{
    TReadDto Create(TCreateDto createDto);
    IEnumerable<TReadDto> GetAll();

    IEnumerable<TReadDto> GetAllPaginated(int page, int pageSize);
    TReadDto? Get(int id);
    TReadDto Update(int id, TUpdateDto updateDto);
    void Delete(int id);
}