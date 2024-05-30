using project.BL.Models;
using project.DAL.Entities;

namespace project.BL.Facades.Interfaces;

public interface IActivityFacade : IFacade<ActivityEntity, ActivityListModel, ActivityModel>
{
    Task SaveAsync(ActivityModel model, Guid subjectId, Guid teacherId);
    Task<IEnumerable<ActivityListModel>> FilterBySubjectsAsync(IEnumerable<ActivityListModel> activities, Guid subjectId, DateTime startDate, DateTime endDate);
    IEnumerable<ActivityListModel> GetSortedActivities(IEnumerable<ActivityListModel> activities, string sortBy, bool descending = false);
}
