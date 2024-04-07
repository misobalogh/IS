using project.BL.Models;
using project.DAL.Entities;

namespace project.BL.Mappers;

public class SubjectModelMapper :
        ModelMapperBase<SubjectEntity, SubjectListModel, SubjectModel>
{
    public override SubjectListModel MapToListModel(SubjectEntity? entity)
        => entity is null
            ? SubjectListModel.Empty
            : new SubjectListModel
            {
                Id = entity.Id,
                SubjectName = entity.Name,
                SubjectTag = entity.Tag
            };

    public override SubjectModel MapToDetailModel(SubjectEntity? entity)
        => entity is null
            ? SubjectModel.Empty
            : new SubjectModel
            {
                Id = entity.Id,
                Name = entity.Name,
                Tag = entity.Tag,
                Semester = entity.Semester,
                //TODO: dodelat v entitach totalPoints, description, ...
            };

    public override SubjectEntity MapToEntity(SubjectModel model)
        => new()
        {
            Id = model.Id,
            Name = model.Name,
            Tag = model.Tag,
            Semester = model.Semester
        };
}
