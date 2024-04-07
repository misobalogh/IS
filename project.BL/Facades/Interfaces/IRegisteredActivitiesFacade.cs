using project.BL.Models;
using project.DAL.Entities;

namespace project.BL.Facades;

public interface IRegisteredActivitiesFacade : IFacade<RegisteredActivitiesEntity, RegisteredActivitiesListModel, RegisteredActivitiesModel>
{
    Task SaveAsync(RegisteredActivitiesModel model, Guid studentId);
}
