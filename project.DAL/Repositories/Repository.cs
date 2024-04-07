using Microsoft.EntityFrameworkCore;
using project.DAL.Entities;
using project.DAL.Mappers;

namespace project.DAL.Repositories;

public class Repository<TEntity>(
    DbContext dbContext,
    IEntityMapper<TEntity> entityMapper
    ) : IRepository<TEntity>
    where TEntity : class, IEntity
{
    private readonly DbSet<TEntity> _dbSet = dbContext.Set<TEntity>();

    public IQueryable<TEntity> Get() => _dbSet;

    public async Task DeleteAsync(Guid entityId) 
        => _dbSet.Remove(await _dbSet.SingleAsync(e => e.Id == entityId).ConfigureAwait(false));

    public async ValueTask<bool> ExistsAsync(TEntity entity)
        => entity.Id != Guid.Empty
           && await _dbSet.AnyAsync(e => e.Id == entity.Id).ConfigureAwait(false);

    public async Task<TEntity> InsertAsync(TEntity entity) => (await _dbSet.AddAsync(entity)).Entity;

    public async Task<TEntity> UpdateAsync(TEntity entity)
    {
        TEntity existingEntity = await _dbSet.SingleAsync(e => e.Id == entity.Id).ConfigureAwait(false);
        entityMapper.MapToExistingEntity(existingEntity, entity);
        return existingEntity;
    }
}
