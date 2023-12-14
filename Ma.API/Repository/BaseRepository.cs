using Ma.API.Data;
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

    public void Create(TEntity entity)
    {
        _context.Set<TEntity>().Add(entity);
        _context.SaveChanges();
    }

    public IEnumerable<TEntity> Get()
    {
        return _context.Set<TEntity>().ToList();
    }

    public IEnumerable<TEntity> GetAllReadOnly()
    {
        return _context.Set<TEntity>().AsNoTracking().ToList();
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