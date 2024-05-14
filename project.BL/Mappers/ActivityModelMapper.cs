using project.BL.Models;
using project.DAL.Entities;

namespace project.BL.Mappers;

public class ActivityModelMapper :
    ModelMapperBase<ActivityEntity, ActivityListModel, ActivityModel>
{
    public override ActivityListModel MapToListModel(ActivityEntity? entity)
        => entity is null
            ? ActivityListModel.Empty
            : new ActivityListModel
            {
                Id = entity.Id,
                End = entity.End,
                Room = entity.Room,
                Start = entity.Start,
                Name = entity.Name,
                SubjectId = entity.SubjectId,
                Capacity = entity.Capacity,
                SubjectName =  entity.Subject.Name,
                Tag = entity.Subject.Tag,
                ActivityType = entity.ActivityType,
                TeacherName = entity.Teacher.LastName,
                Points = 0
            };

    //TODO: v kucharce se predavaji Id pres parametry, tak to udelat taky tak?
    public override ActivityModel MapToDetailModel(ActivityEntity? entity)
        => entity is null
            ? ActivityModel.Empty
            : new ActivityModel
            {
                Id = entity.Id,
                End = entity.End,
                Room = entity.Room,
                Start = entity.Start,
                Name = entity.Name,
                ActivityType = entity.ActivityType,
                SubjectId = entity.SubjectId,
                SubjectName = entity.Subject.Name,
                Capacity = entity.Capacity,
                TeacherName = entity.Teacher.LastName, //TODO: nejakou metodu na ziskani celeho jmena i s tituly?
                MaxPoints = entity.MaxPoints,
                TeacherId = entity.TeacherId
            };
    public override ActivityEntity MapToEntity(ActivityModel model)
        => throw new NotImplementedException("This method is unsupported. Use the other overload.");
    
    public ActivityEntity MapToEntity(ActivityModel model, Guid subjectId, Guid teacherId)
        => new()
        {
            Id = model.Id,
            Capacity = model.Capacity,
            End = model.End,
            Room = model.Room,
            Start = model.Start,
            Subject = null!,
            Teacher = null!,
            MaxPoints = model.MaxPoints,
            Name = model.Name,
            ActivityType = model.ActivityType,
            SubjectId = subjectId,
            TeacherId = teacherId
        };
}
