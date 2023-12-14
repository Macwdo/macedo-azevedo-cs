namespace Ma.API.Repository;

public class BaseRepository<T, TU> : IRepository<T, TU> where T : class
{
    public T Save(T entity)
    {
        throw new NotImplementedException();
    }

    public IQueryable Queryable()
    {
        throw new NotImplementedException();
    }

    public T Create(T entity)
    {
        throw new NotImplementedException();
    }

    public IEnumerable<T> Get()
    {
        throw new NotImplementedException();
    }

    public T Get(TU id)
    {
        throw new NotImplementedException();
    }

    public T Update(T entity)
    {
        throw new NotImplementedException();
    }

    public void Delete(TU id)
    {
        throw new NotImplementedException();
    }

    public Task<T> CreateAsync(T entity)
    {
        throw new NotImplementedException();
    }

    public Task<IEnumerable<T>> GetAsync()
    {
        throw new NotImplementedException();
    }

    public Task<T> GetAsync(TU id)
    {
        throw new NotImplementedException();
    }

    public Task<T> UpdateAsync(T entity)
    {
        throw new NotImplementedException();
    }

    public Task DeleteAsync(TU id)
    {
        throw new NotImplementedException();
    }
}