using project.BL.Models;
using project.DAL.Entities;

namespace project.BL.Mappers;

public class RegisteredActivitiesModelMapper : 
    ModelMapperBase<RegisteredActivitiesEntity, RegisteredActivitiesListModel, RegisteredActivitiesModel>
{
    public override RegisteredActivitiesListModel MapToListModel(RegisteredActivitiesEntity? entity)
        => entity is null
            ? RegisteredActivitiesListModel.Empty
            : new RegisteredActivitiesListModel
            {
                StudentId = entity.StudentId,
                ActivityId = entity.ActivityId,
                ActivityName = entity.Activity.Name,
                End = entity.Activity.End,
                Room = entity.Activity.Room,
                Start = entity.Activity.Start,
                Id = entity.Id
            };

    public override RegisteredActivitiesModel MapToDetailModel(RegisteredActivitiesEntity? entity)
        => entity is null
            ? RegisteredActivitiesModel.Empty
            : new RegisteredActivitiesModel
            {
                StudentId = entity.StudentId,
                ActivityId = entity.ActivityId,
                ActivityName = entity.Activity.Name,
                End = entity.Activity.End,
                Room = entity.Activity.Room,
                Start = entity.Activity.Start,
                Id = entity.Id
            };

    public override RegisteredActivitiesEntity MapToEntity(RegisteredActivitiesModel model)
        => throw new NotImplementedException("This method is unsupported. Use the other overload.");
    
    public RegisteredActivitiesEntity MapToEntity(RegisteredActivitiesModel model, Guid studentId)
        => new()
        {
            Activity = null!,
            Id = model.Id,
            Student = null!,
            ActivityId = model.ActivityId,
            StudentId = studentId
        };
}
