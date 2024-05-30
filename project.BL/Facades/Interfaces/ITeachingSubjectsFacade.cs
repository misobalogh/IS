using project.BL.Facades.Interfaces;
using project.BL.Models;
using project.DAL.Entities;

namespace project.BL.Facades;

public interface ITeachingSubjectsFacade : IFacade<TeachingSubjectsEntity, TeachingSubjectsListModel, TeachingSubjectsModel>
{
    Task SaveAsync(TeachingSubjectsModel model, Guid subjectId);
}
