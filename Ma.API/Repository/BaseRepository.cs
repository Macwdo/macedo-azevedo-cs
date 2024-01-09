using Ma.API.Data;
using Ma.API.Exceptions;
using Microsoft.EntityFrameworkCore;

namespace Ma.API.Repository;

public class BaseRepository<TEntity> : IRepository<TEntity> where TEntity : class
{

    private readonly ApplicationContext _context;
    public BaseRepository(ApplicationContext context)
    {
        _context = context;
    }

    public void Save(TEntity entity)
    {
        _context.SaveChanges();
    }

    public IQueryable GetQueryable()
    {
        return _context.Set<TEntity>().AsQueryable();
    }

    public TEntity Create(TEntity entity)
    {
        _context.Set<TEntity>().Add(entity);
        _context.SaveChanges();
        return entity;

    }

    public IEnumerable<TEntity> Get()
    {
        return _context.Set<TEntity>().ToList();
    }

    public IEnumerable<TEntity> GetAllReadOnly()
    {
        return _context.Set<TEntity>().AsNoTracking().ToList();
    }

    public IEnumerable<TEntity> GetAllReadOnlyPaginated(int skip, int take)
    {
        skip = skip == 0 ? 1 : skip;
        return _context.Set<TEntity>()
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
        return _context.Set<TEntity>()
            .AsEnumerable()
            .OrderByDescending(x => x.GetType().GetProperty("Id")?.GetValue(x))
            .Skip((skip - 1) * take)
            .Take(take)
            .ToList();
    }

    public TEntity? Get(int id)
    {
        return _context.Set<TEntity>().Find(id);
    }

    public TEntity Update(TEntity entity)
    {
        _context.Set<TEntity>().Update(entity);
        _context.SaveChanges();
        return entity;
    }

    public void Delete(TEntity entity)
    {
            _context.Set<TEntity>().Remove(entity);
            _context.SaveChanges();
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