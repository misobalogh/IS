using project.BL.Models;
using project.DAL.Entities;

namespace project.BL.Mappers;

public class TeacherModelMapper : 
    ModelMapperBase<TeacherEntity, TeacherListModel, TeacherModel>
{
    public override TeacherListModel MapToListModel(TeacherEntity? entity)
        => entity is null
            ? TeacherListModel.Empty
            : new TeacherListModel
            {
                Id = entity.Id,
                FirstName = entity.FirstName,
                LastName = entity.LastName,
                PhotoUrl = entity.Image,
                TitleBefore = entity.TitleBefore,
                TitleAfter = entity.TitleAfter,
                Email = entity.Email,
            };

    public override TeacherModel MapToDetailModel(TeacherEntity? entity)
        => entity is null
            ? TeacherModel.Empty
            : new TeacherModel
            {
                Id = entity.Id,
                Email = entity.Email,
                Password = entity.Password,
                FirstName = entity.FirstName,
                LastName = entity.LastName,
                PhotoUrl = entity.Image,
                TitleBefore = entity.TitleBefore,
                TitleAfter = entity.TitleAfter,
                // TODO: TeachingSubjects = subjectModelMapper.MapToListModel(entity.Subjects)
                //  .ToObservableCollection
            };

    public override TeacherEntity MapToEntity(TeacherModel model) 
        => new()
        {
            Id = model.Id,
            FirstName = model.FirstName,
            LastName = model.LastName,
            Email = model.Email,
            Password = model.Password,
            Image = model.PhotoUrl,
            TitleBefore = model.TitleBefore,
            TitleAfter = model.TitleAfter
        };
}
