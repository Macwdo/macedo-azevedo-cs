namespace Ma.API.Repository;

public interface IRepository<TEntity> where TEntity : class
{
    void Save(TEntity entity);
    IQueryable GetQueryable();

    void Create(TEntity entity);
    IEnumerable<TEntity> Get();
    IEnumerable<TEntity> GetAllFilteredByStringSearch(string search);
    IEnumerable<TEntity> GetAllReadOnly();

    TEntity? Get(int id);
    TEntity Update(TEntity entity);
    void Delete(TEntity entity);



    Task<TEntity> CreateAsync(TEntity entity);
    Task<IEnumerable<TEntity>> GetAsync();
    Task<TEntity> GetAsync(int id);
    Task<TEntity> UpdateAsync(TEntity entity);
    Task DeleteAsync(int id);
}