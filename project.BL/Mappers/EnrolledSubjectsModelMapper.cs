using project.BL.Models;
using project.DAL.Entities;

namespace project.BL.Mappers;

public class EnrolledSubjectsModelMapper :
    ModelMapperBase<EnrolledSubjectEntity, EnrolledSubjectsListModel, EnrolledSubjectsModel>
{
    public override EnrolledSubjectsListModel MapToListModel(EnrolledSubjectEntity? entity)
        => entity is null
            ? EnrolledSubjectsListModel.Empty
            : new EnrolledSubjectsListModel
            {
                Mark = entity.Mark,
                Points = entity.Points,
                SubjectName = entity.Subject.Name,
                Id = entity.Id,
                SubjectId = entity.SubjectId,
                StudentId = entity.StudentId,
            };

    public override EnrolledSubjectsModel MapToDetailModel(EnrolledSubjectEntity? entity)
        => entity is null
            ? EnrolledSubjectsModel.Empty
            : new EnrolledSubjectsModel
            {
                Mark = entity.Mark,
                Points = entity.Points,
                SubjectId = entity.SubjectId,
                SubjectName = entity.Subject.Name,
                Id = entity.Id,
                Year = entity.Year,
                StudentId = entity.StudentId
            };

    public override EnrolledSubjectEntity MapToEntity(EnrolledSubjectsModel model)
        => throw new NotImplementedException("This method is unsupported. Use the other overload.");
    
    public EnrolledSubjectEntity MapToEntity(EnrolledSubjectsModel model, Guid studentId)
        => new()
        {
            Id = model.Id,
            Mark = model.Mark,
            Points = model.Points,
            Student = null!,
            Subject = null!,
            Year = model.Year,
            SubjectId = model.SubjectId,
            StudentId = studentId
        };
}

