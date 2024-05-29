using project.BL.Models;
using project.DAL.Entities;

namespace project.BL.Mappers;

public class TeachingSubjectsModelMapper :
    ModelMapperBase<TeachingSubjectsEntity, TeachingSubjectsListModel, TeachingSubjectsModel>
{
    public override TeachingSubjectsListModel MapToListModel(TeachingSubjectsEntity? entity)
        => entity is null
            ? TeachingSubjectsListModel.Empty
            : new TeachingSubjectsListModel
            {
                Id = entity.Id,
                SubjectId = entity.SubjectId,
                Year = entity.Year,
            };

    public override TeachingSubjectsModel MapToDetailModel(TeachingSubjectsEntity? entity)
        => entity is null
            ? TeachingSubjectsModel.Empty
            : new TeachingSubjectsModel
            {
                Id = entity.Id,
                SubjectId = entity.SubjectId,
                Year = entity.Year,
            };

    public TeachingSubjectsListModel MapToListModel(TeachingSubjectsModel model)
        => new()
        {
            Id = model.Id,
            SubjectId = model.SubjectId,
            Year = model.Year,
        };

    public void MapToExistingDetailModel(TeachingSubjectsModel existingDetailModel,
        SubjectListModel subject)
    {
        existingDetailModel.SubjectId = subject.Id;
    }

    public override TeachingSubjectsEntity MapToEntity(TeachingSubjectsModel model)
        => throw new NotImplementedException("This method is unsupported. Use the other overload.");
    
    public TeachingSubjectsEntity MapToEntity(TeachingSubjectsModel model, Guid TeacherId)
        => new()
        {
            Id = model.Id,
            Year = model.Year,
            SubjectId = model.SubjectId,
            TeacherId = TeacherId,
            Subject = null!,
            Teacher = null!,
        };

    public TeachingSubjectsEntity MapToEntity(TeachingSubjectsListModel model, Guid TeacherId)
        => new()
        {
            Id = model.Id,
            Year = model.Year,
            SubjectId = model.SubjectId,
            TeacherId = TeacherId,
            Subject = null!,
            Teacher = null!,
        };
}

