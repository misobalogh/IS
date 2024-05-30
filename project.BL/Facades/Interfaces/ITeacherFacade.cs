using project.BL.Facades.Interfaces;
using project.BL.Models;
using project.DAL.Entities;

namespace project.BL.Facades;

public interface ITeacherFacade : IFacade<TeacherEntity, TeacherListModel, TeacherModel>
{
    Task<List<TeacherListModel>> SearchTeacher(string searchTerm);
    Task<bool> EmailExistsAsync(string email);
    public IEnumerable<TeacherListModel> Sort(IEnumerable<TeacherListModel> teachers, string sortBy, bool descending);
}
