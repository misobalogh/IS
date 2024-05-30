using project.BL.Models;
using project.DAL.Entities;

namespace project.BL.Mappers;

public class EvaluationModelMapper :
    ModelMapperBase<EvaluationEntity, EvaluationListModel, EvaluationModel>
{
    public override EvaluationListModel MapToListModel(EvaluationEntity? entity)
        => entity is null
            ? EvaluationListModel.Empty
            : new EvaluationListModel
            {
                Points = entity.Points,
                StudentId = entity.StudentId,
                ActivityId = entity.ActivityId,
                Id = entity.Id,
            };

    public override EvaluationModel MapToDetailModel(EvaluationEntity? entity)
        => entity is null
            ? EvaluationModel.Empty
            : new EvaluationModel
            {
                Points = entity.Points,
                StudentId = entity.StudentId,
                Id = entity.Id,
                Note = entity.Note,
                ActivityId = entity.ActivityId,
            };

    public override EvaluationEntity MapToEntity(EvaluationModel model)
        => new()
        {
            Id = model.Id,
            Points = model.Points,
            Student = null!,
            StudentId = model.StudentId,
            Note = model.Note,
            ActivityId = model.ActivityId,
            Activity = null!
        };
}
