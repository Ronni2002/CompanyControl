using ControlCompany.Entities;
using ControlCompany.Interfaces.Repositories;
using Microsoft.EntityFrameworkCore;

namespace ControlCompany.Repositories;

public class Repository<TEntity>:IRepository<TEntity> where TEntity: BaseEntity
{
    private readonly DbContext _context;

    public Repository(DbContext context)
    {
        _context = context;
    }
    
    /// <inheritdoc />
    public Task<TEntity?> GetByIdAsync(Guid id, CancellationToken cancellationToken = default)
    {
        return _context.Set<TEntity>().FirstOrDefaultAsync(e => e.Id == id, cancellationToken);
    }
    
    /// <inheritdoc />
    public Task AddAsync(TEntity entity, CancellationToken cancellationToken = default)
    {
        entity.Created = DateTimeOffset.Now;
        cancellationToken.ThrowIfCancellationRequested();
        _context.Add(entity);
        return Task.CompletedTask;
    }
    
    /// <inheritdoc />
    public Task AddRangeAsync(List<TEntity> entities, CancellationToken cancellationToken = default) 
    {
        foreach (var entity in entities) 
        {
            entity.Created = DateTimeOffset.Now;
            cancellationToken.ThrowIfCancellationRequested();
            _context.Add(entity);
        }

        return Task.CompletedTask;
    }

    /// <inheritdoc />
    public Task<TEntity> UpdateAsync(TEntity entity, CancellationToken cancellationToken = default)
    {
        entity.Updated = DateTimeOffset.Now;
        cancellationToken.ThrowIfCancellationRequested();
        _context.Entry(entity).State = EntityState.Modified;
        return Task.FromResult(entity);
    }

    /// <inheritdoc />
    public virtual Task DeleteAsync(TEntity entity, CancellationToken cancellationToken = default)
    {
        cancellationToken.ThrowIfCancellationRequested();
        _context.Set<TEntity>().Remove(entity);
        return Task.CompletedTask;
    }
    
    /// <inheritdoc />
    public Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
    {
        return _context.SaveChangesAsync(cancellationToken);
    }
}