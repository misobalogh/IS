using project.BL.Models;
using project.DAL.Entities;

namespace project.BL.Facades.Interfaces;

public interface IActivityFacade : IFacade<ActivityEntity, ActivityListModel, ActivityModel>
{
    Task SaveAsync(ActivityModel model, Guid subjectId, Guid teacherId);
    Task<List<ActivityListModel>> FilterBySubjects(Guid subjectId, DateTime startDate, DateTime endDate);
    Task<List<ActivityListModel>> GetSortedActivities(string sortBy, bool descending = false);
}
