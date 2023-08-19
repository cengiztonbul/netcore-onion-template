using Microsoft.EntityFrameworkCore;
using OnionTemplate.Application.Interfaces.Repositories;
using OnionTemplate.Domain;
using OnionTemplate.Persistence.Context;

namespace OnionTemplate.Persistence;

public class BaseRepository<T> : IBaseRepository<T> where T : BaseEntity
{
    private readonly ApplicationDbContext _dbContext;

    public BaseRepository(ApplicationDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task<List<T>> GetAllAsync()
    {
        return await _dbContext.Set<T>().ToListAsync();
    }

    public async Task<T> GetByIdAsync(Guid id)
    {
        return await _dbContext.Set<T>().FindAsync(id);
    }

    public async Task<T> CreateAsync(T entity)
    {
        entity.Id = Guid.NewGuid();
        await _dbContext.Set<T>().AddAsync(entity);
        await _dbContext.SaveChangesAsync();
        return entity;
    }

    public async Task<T> DeleteAsync(Guid id)
    {
        T entityToRemove = await GetByIdAsync(id);
        if (entityToRemove == null || entityToRemove.Id == Guid.Empty)
        {
            return entityToRemove;
        }
        _dbContext.Set<T>().Remove(entityToRemove);
        await _dbContext.SaveChangesAsync();
        return entityToRemove;
    }
}
