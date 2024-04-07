using project.BL.Models;
using project.DAL.Entities;

namespace project.BL.Facades;

public interface IActivityFacade : IFacade<ActivityEntity, ActivityListModel, ActivityModel>
{
    Task SaveAsync(ActivityModel model, Guid evaluationId, Guid subjectId, Guid teachearId);
}
