using Microsoft.EntityFrameworkCore;
using System.Reflection;
using project.BL.Facades.Interfaces;
using project.BL.Mappers;
using project.BL.Models;
using project.BL.Services;
using project.DAL;
using project.DAL.Entities;
using project.DAL.Mappers;
using project.DAL.Repositories;
using project.DAL.UnitOfWork;

namespace project.BL.Facades;

public class ActivityFacade(IUnitOfWorkFactory unitOfWorkFactory, ActivityModelMapper activityModelMapper) 
    : FacadeBase<ActivityEntity, ActivityListModel, ActivityModel, ActivityEntityMapper>(unitOfWorkFactory, activityModelMapper), IActivityFacade
{

    
    public async Task SaveAsync(ActivityModel model, Guid subjectId, Guid teacherId)
    {
        ActivityEntity entity = activityModelMapper.MapToEntity(model, subjectId, teacherId);

        await using IUnitOfWork unitOfWork = UnitOfWorkFactory.Create();
        IRepository<ActivityEntity> repository =
            unitOfWork.GetRepository<ActivityEntity, ActivityEntityMapper>();

        if (await repository.ExistsAsync(entity))
        {
            await repository.UpdateAsync(entity);
            await unitOfWork.CommitAsync();
        }
    }


    public async Task<List<ActivityListModel>> FilterBySubjects(Guid subjectId, DateTime startDate, DateTime endDate)
    {
        await using IUnitOfWork unitOfWork = UnitOfWorkFactory.Create();
        IRepository<ActivityEntity> repository = unitOfWork.GetRepository<ActivityEntity, ActivityEntityMapper>();

        IQueryable<ActivityEntity> query = repository.Get()
            .Where(activity => activity.SubjectId == subjectId)
            .Where(activity => activity.Start >= startDate && activity.End <= endDate);

        IEnumerable<ActivityListModel> activityModels = activityModelMapper.MapToListModel(query);

        return activityModels.ToList();
    }

    // Sort activities dynamically based on property name and direction
    public async Task<List<ActivityListModel>> GetSortedActivities(string sortBy, bool descending = false)
    {
        await using IUnitOfWork unitOfWork = UnitOfWorkFactory.Create();
        var repository = unitOfWork.GetRepository<ActivityEntity, ActivityEntityMapper>();
        var activities = await repository.Get().ToListAsync();

        PropertyInfo? propInfo = typeof(ActivityListModel).GetProperty(sortBy);
        if (propInfo == null)
        {
            throw new ArgumentException($"'{sortBy}' is not a valid property of ActivityListModel");
        }

        var sortedActivities = descending
            ? activities.OrderByDescending(a => propInfo.GetValue(a, null))
            : activities.OrderBy(a => propInfo.GetValue(a, null));

        return sortedActivities.Select(activityModelMapper.MapToListModel).ToList();
    }
}
