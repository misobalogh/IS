using project.BL.Mappers;
using project.BL.Models;
using project.DAL.Entities;
using project.DAL.Mappers;
using project.DAL.Repositories;
using project.DAL.UnitOfWork;

namespace project.BL.Facades;

public class ActivityFacade(IUnitOfWorkFactory unitOfWorkFactory, ActivityModelMapper activityModelMapper) 
    : FacadeBase<ActivityEntity, ActivityListModel, ActivityModel, ActivityEntityMapper>(unitOfWorkFactory, activityModelMapper), IActivityFacade
{
    public async Task SaveAsync(ActivityModel model, Guid evaluationId, Guid subjectId, Guid teachearId)
    {
        ActivityEntity entity = activityModelMapper.MapToEntity(model, evaluationId, subjectId, teachearId);

        await using IUnitOfWork unitOfWork = UnitOfWorkFactory.Create();
        IRepository<ActivityEntity> repository =
            unitOfWork.GetRepository<ActivityEntity, ActivityEntityMapper>();

        if (await repository.ExistsAsync(entity))
        {
            await repository.UpdateAsync(entity);
            await unitOfWork.CommitAsync();
        }
    }
}
