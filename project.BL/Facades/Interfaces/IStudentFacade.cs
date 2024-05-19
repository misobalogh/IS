using project.BL.Facades.Interfaces;
using project.BL.Models;
using project.DAL.Entities;

namespace project.BL.Facades;

public interface IStudentFacade : IFacade<StudentEntity, StudentListModel, StudentModel>
{
    Task<List<StudentListModel>> SearchStudent(string searchTerm);
    Task<bool> EmailExistsAsync(string email);
}
