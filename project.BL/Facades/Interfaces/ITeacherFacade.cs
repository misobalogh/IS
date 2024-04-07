using project.BL.Models;
using project.DAL.Entities;

namespace project.BL.Facades;

public interface ITeacherFacade : IFacade<TeacherEntity, TeacherListModel, TeacherModel>
{
    //Task SaveAsync(TeacherModel model);
}
