namespace Ma.API.Repository;

public interface IRepository<TEntity> where TEntity : class
{
    void Save(TEntity entity);
    IQueryable GetQueryable();

    TEntity Create(TEntity entity);
    IEnumerable<TEntity> Get();
    IEnumerable<TEntity> GetAllReadOnly();
    IEnumerable<TEntity> GetAllReadOnlyPaginated(int skip, int take);
    IEnumerable<TEntity> GetAllPaginated(int skip, int take);

    TEntity? Get(int id);
    TEntity Update(TEntity entity);
    void Delete(TEntity entity);



    Task<TEntity> CreateAsync(TEntity entity);
    Task<IEnumerable<TEntity>> GetAsync();
    Task<TEntity> GetAsync(int id);
    Task<TEntity> UpdateAsync(TEntity entity);
    Task DeleteAsync(int id);
}