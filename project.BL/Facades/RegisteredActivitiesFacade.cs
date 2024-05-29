using project.BL.Mappers;
using project.BL.Models;
using project.DAL.Entities;
using project.DAL.Mappers;
using project.DAL.Repositories;
using project.DAL.UnitOfWork;

namespace project.BL.Facades;

public class RegisteredActivitiesFacade(IUnitOfWorkFactory unitOfWorkFactory, RegisteredActivitiesModelMapper registeredActivitiesModelMapper) 
    : FacadeBase<RegisteredActivitiesEntity, RegisteredActivitiesListModel, RegisteredActivitiesModel, RegisteredActivitiesEntityMapper>(unitOfWorkFactory, registeredActivitiesModelMapper), IRegisteredActivitiesFacade
{
    protected override List<string> IncludesNavigationPathDetail =>
        [$"{nameof(RegisteredActivitiesEntity.Student)}", $"{nameof(RegisteredActivitiesEntity.Activity)}"];

    public async Task SaveAsync(RegisteredActivitiesModel model, Guid studentId)
    {
        RegisteredActivitiesEntity entity = registeredActivitiesModelMapper.MapToEntity(model, studentId);

        await using IUnitOfWork unitOfWork = UnitOfWorkFactory.Create();
        IRepository<RegisteredActivitiesEntity> repository =
            unitOfWork.GetRepository<RegisteredActivitiesEntity, RegisteredActivitiesEntityMapper>();

        if (await repository.ExistsAsync(entity))
        {
            await repository.UpdateAsync(entity);
            await unitOfWork.CommitAsync();
        }
        else
        {
            await repository.InsertAsync(entity);
            await unitOfWork.CommitAsync();
        }
    }
}
