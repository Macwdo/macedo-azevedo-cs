using Ma.API.Data;
using Ma.API.Entities;
using Microsoft.EntityFrameworkCore;

namespace Ma.API.Repository;

public class BaseRepository<TEntity> : IRepository<TEntity> where TEntity : BaseEntity
{

    private readonly ApplicationDbContext _dbContext;
    public BaseRepository(ApplicationDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public void Save(TEntity entity)
    {
        _dbContext.SaveChanges();
    }

    public IQueryable GetQueryable()
    {
        return _dbContext.Set<TEntity>().AsQueryable();
    }

    public TEntity Create(TEntity entity)
    {
        _dbContext.Set<TEntity>().Add(entity);
        _dbContext.SaveChanges();
        return entity;

    }

    public IEnumerable<TEntity> Get()
    {
        return _dbContext.Set<TEntity>().ToList();
    }

    public IEnumerable<TEntity> GetAllReadOnly()
    {
        return _dbContext.Set<TEntity>().AsNoTracking().ToList();
    }

    public IEnumerable<TEntity> GetAllReadOnlyPaginated(int skip, int take)
    {
        skip = skip == 0 ? 1 : skip;
        return _dbContext.Set<TEntity>()
            .AsNoTracking()
            .AsEnumerable()
            .OrderBy(x => x.GetType().GetProperty("Id")?.GetValue(x))
            .Skip((skip - 1) * take)
            .Take(take)
            .ToList();
    }

    public IEnumerable<TEntity> GetAllPaginated(int skip, int take)
    {
        skip = skip == 0 ? 1 : skip;
        return _dbContext.Set<TEntity>()
            .AsEnumerable()
            .OrderByDescending(x => x.Id)
            .Skip((skip - 1) * take)
            .Take(take)
            .ToList();
    }

    public TEntity? Get(int id)
    {
        return _dbContext.Set<TEntity>().Find(id);
    }

    public TEntity Update(TEntity entity)
    {
        _dbContext.Set<TEntity>().Update(entity);
        _dbContext.SaveChanges();
        return entity;
    }

    public void Delete(TEntity entity)
    {
            _dbContext.Set<TEntity>().Remove(entity);
            _dbContext.SaveChanges();
    }

    public Task<TEntity> CreateAsync(TEntity entity)
    {
        throw new NotImplementedException();
    }

    public Task<IEnumerable<TEntity>> GetAsync()
    {
        throw new NotImplementedException();
    }

    public Task<TEntity> GetAsync(int id)
    {
        throw new NotImplementedException();
    }

    public Task<TEntity> UpdateAsync(TEntity entity)
    {
        throw new NotImplementedException();
    }

    public Task DeleteAsync(int id)
    {
        throw new NotImplementedException();
    }
}