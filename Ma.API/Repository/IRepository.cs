namespace Ma.API.Repository;

public interface IRepository<T, in TU> where T : class
{
    T Save(T entity);
    IQueryable Queryable();

    T Create(T entity);
    IEnumerable<T> Get();
    T Get(TU id);
    T Update(T entity);
    void Delete(TU id);

    Task<T> CreateAsync(T entity);
    Task<IEnumerable<T>> GetAsync();
    Task<T> GetAsync(TU id);
    Task<T> UpdateAsync(T entity);
    Task DeleteAsync(TU id);
}