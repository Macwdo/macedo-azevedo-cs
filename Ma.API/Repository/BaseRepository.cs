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
        try
        {
            _context.SaveChanges();
        }
        catch
        {
            throw new InternalException("Error trying to save changes");
        }
    }

    public IQueryable GetQueryable()
    {
        return _context.Set<TEntity>().AsQueryable();
    }

    public TEntity Create(TEntity entity)
    {
        try
        {
            _context.Set<TEntity>().Add(entity);
            _context.SaveChanges();
            return entity;
        }
        catch (Exception)
        {
            throw new InternalException($"Error trying to create the entity: {entity}");
        }

    }

    public IEnumerable<TEntity> Get()
    {
        return _context.Set<TEntity>().ToList();
    }

    public IEnumerable<TEntity> GetAllFilteredByStringSearch(string search)
    {
        throw new NotImplementedException();
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
        try
        {
            _context.Set<TEntity>().Update(entity);
            _context.SaveChanges();
        }
        catch (Exception)
        {
            throw new InternalException($"Error trying to update the entity: {entity}.");
        }
        return entity;
    }

    public void Delete(TEntity entity)
    {
        try
        {
            _context.Set<TEntity>().Remove(entity);
            _context.SaveChanges();
        }
        catch (Exception)
        {
            throw new InternalException($"Error trying to delete the entity: {entity}.");
        }
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