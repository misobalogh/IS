using project.BL.Models;
using project.DAL.Entities;

namespace project.BL.Mappers;

public class StudentModelMapper :
    ModelMapperBase<StudentEntity, StudentListModel, StudentModel>
{
    public override StudentListModel MapToListModel(StudentEntity? entity)
        => entity is null
            ? StudentListModel.Empty
            : new StudentListModel
            {
                Id = entity.Id,
                Grade = entity.Grade,
                FirstName = entity.FirstName,
                LastName = entity.LastName,
                Email = entity.Email,
                PhotoUrl = entity.Image
            };

    public override StudentModel MapToDetailModel(StudentEntity? entity)
        => entity is null
            ? StudentModel.Empty
            : new StudentModel
            {
                Id = entity.Id,
                Email = entity.Email,
                Grade = entity.Grade,
                FirstName = entity.FirstName,
                LastName = entity.LastName,
                Image = entity.Image,
                Password = entity.Password,
                //EnrolledSubjects = enrolledSubjectsModelMapper.MapToListModel(entity.EnrolledSubjects)
                //    .ToObservableCollection(),
                //RegisteredActivities = registeredActivitiesModelMapper.MapToListModel(entity.RegisteredActivities)
                //    .ToObservableCollection(),
                //Evaluation = evaluationModelMapper.MapToListModel(entity.Evaluations)
                //    .ToObservableCollection(),
            };

    public override StudentEntity MapToEntity(StudentModel model)
        => new()
        {
            Id = model.Id,
            Email = model.Email,
            Password = model.Password,
            FirstName = model.FirstName,
            LastName = model.LastName,
            Image = model.Image,
            Grade = model.Grade,
            EnrolledSubjects = null!,
            RegisteredActivities = null!,
        };
}
