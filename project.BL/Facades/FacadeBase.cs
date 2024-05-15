using System.Collections;
using System.Reflection;
using Microsoft.EntityFrameworkCore;
using project.BL.Facades.Interfaces;
using project.BL.Mappers;
using project.BL.Models;
using project.DAL.Entities;
using project.DAL.Mappers;
using project.DAL.Repositories;
using project.DAL.UnitOfWork;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;

namespace project.BL.Facades;

public abstract class FacadeBase<TEntity, TListModel, TDetailModel, TEntityMapper>(
        IUnitOfWorkFactory unitOfWorkFactory,
        IModelMapper<TEntity, TListModel, TDetailModel> modelMapper)
    : IFacade<TEntity, TListModel, TDetailModel>
    where TEntity : class, IEntity
    where TListModel : IModel
    where TDetailModel : class, IModel
    where TEntityMapper : IEntityMapper<TEntity>, new()
{
    protected readonly IModelMapper<TEntity, TListModel, TDetailModel> ModelMapper = modelMapper;
    protected readonly IUnitOfWorkFactory UnitOfWorkFactory = unitOfWorkFactory;

    protected virtual List<string> IncludesNavigationPathDetail => [];

    public async Task DeleteAsync(Guid id)
    {
        await using IUnitOfWork unitOfWork = UnitOfWorkFactory.Create();
        try
        {
            await unitOfWork.GetRepository<TEntity, TEntityMapper>().DeleteAsync(id);
            await unitOfWork.CommitAsync().ConfigureAwait(false);
        }
        catch (DbUpdateException ex)
        {
            throw new InvalidOperationException("Entity deletion failed.", ex);
        }
    }

    public virtual async Task<TDetailModel?> GetAsync(Guid id)
    {
        await using IUnitOfWork unitOfWork = UnitOfWorkFactory.Create();

        IQueryable<TEntity> query = unitOfWork.GetRepository<TEntity, TEntityMapper>().Get();
        if (IncludesNavigationPathDetail.Count > 0)
        {
            IncludesNavigationPathDetail.ForEach(i => query = query.Include(i));
        }

        TEntity? entity = await query.SingleOrDefaultAsync(e => e.Id == id);

        return entity is null ? null : ModelMapper.MapToDetailModel(entity);
    }

    public virtual async Task<IEnumerable<TListModel>> GetAsync()
    {
        await using IUnitOfWork unitOfWork = UnitOfWorkFactory.Create();

        IQueryable<TEntity> query = unitOfWork.GetRepository<TEntity, TEntityMapper>().Get();
        if (IncludesNavigationPathDetail.Count > 0)
        {
            IncludesNavigationPathDetail.ForEach(i => query = query.Include(i));
        }

        List<TEntity> entities = await query.ToListAsync();

        return ModelMapper.MapToListModel(entities);
    }

    public virtual async Task<TDetailModel> SaveAsync(TDetailModel model)
    {
        TDetailModel result;

        GuardCollectionsAreNotSet(model);

        TEntity entity = ModelMapper.MapToEntity(model);

        IUnitOfWork uow = UnitOfWorkFactory.Create();
        IRepository<TEntity> repository = uow.GetRepository<TEntity, TEntityMapper>();

        if (await repository.ExistsAsync(entity))
        {
            TEntity updatedEntity = await repository.UpdateAsync(entity);
            result = ModelMapper.MapToDetailModel(updatedEntity);
        }
        else
        {
            entity.Id = Guid.NewGuid();
            TEntity insertedEntity = await repository.InsertAsync(entity);
            result = ModelMapper.MapToDetailModel(insertedEntity);
        }

        await uow.CommitAsync();

        return result;
    }

    /// <summary>
    /// This Guard ensures that there is a clear understanding of current infrastructure limitations.
    /// This version of BL/DAL infrastructure does not support insertion or update of adjacent entities.
    /// WARN: Does not guard navigation properties.
    /// </summary>
    /// <param name="model">Model to be inserted or updated</param>
    /// <exception cref="InvalidOperationException"></exception>
    private static void GuardCollectionsAreNotSet(TDetailModel model)
    {
        IEnumerable<PropertyInfo> collectionProperties = model
            .GetType()
            .GetProperties()
            .Where(i => typeof(ICollection).IsAssignableFrom(i.PropertyType));

        foreach (PropertyInfo collectionProperty in collectionProperties)
        {
            if (collectionProperty.GetValue(model) is ICollection { Count: > 0 })
            {
                throw new InvalidOperationException(
                    "Current BL and DAL infrastructure disallows insert or update of models with adjacent collections.");
            }
        }
    }

}

