using System.Reflection;
using project.BL.Mappers;
using project.BL.Models;
using project.DAL.Entities;
using project.DAL.Mappers;
using project.DAL.Repositories;
using project.DAL.UnitOfWork;

namespace project.BL.Facades;

public class StudentFacade(IUnitOfWorkFactory unitOfWorkFactory, StudentModelMapper studentModelMapper) 
    : FacadeBase<StudentEntity, StudentListModel, StudentModel, StudentEntityMapper>(unitOfWorkFactory, studentModelMapper), IStudentFacade
{
    protected override List<string> IncludesNavigationPathDetail =>
    [
        $"{nameof(StudentEntity.EnrolledSubjects)}.{nameof(EnrolledSubjectEntity.Subject)}",
        $"{nameof(StudentEntity.RegisteredActivities)}.{nameof(RegisteredActivitiesEntity.Activity)}",
        $"{nameof(StudentEntity.Evaluations)}.{nameof(EvaluationEntity.Activity)}",
    ];

    public async Task<List<StudentListModel>> SearchStudent(string searchTerm)
    {
        await using IUnitOfWork unitOfWork = UnitOfWorkFactory.Create();
        var repository = unitOfWork.GetRepository<StudentEntity, StudentEntityMapper>();

        IQueryable<StudentEntity> query = repository.Get()
            .Where(entity => entity.FirstName.ToLower().Contains(searchTerm.ToLower()) || entity.LastName.ToLower().Contains(searchTerm.ToLower()));

        return query.AsEnumerable().Select(studentModelMapper.MapToListModel).ToList();
    }

    public async Task<bool> EmailExistsAsync(string email)
    {
        await using IUnitOfWork unitOfWork = UnitOfWorkFactory.Create();
        var repository = unitOfWork.GetRepository<TeacherEntity, TeacherEntityMapper>();


        IQueryable<TeacherEntity> query = repository.Get().Where(entity => entity.Email == email);
        return query.AsEnumerable().Any();
    }

    public IEnumerable<StudentListModel> Sort(IEnumerable<StudentListModel> students, string sortBy, bool descending)
    {
        PropertyInfo? propInfo = typeof(StudentListModel).GetProperty(sortBy);
        if (propInfo == null)
        {
            throw new ArgumentException($"'{sortBy}' is not a valid property of StudentListModel");
        }

        var sortedStudents = descending
            ? students.OrderByDescending(a => propInfo.GetValue(a, null))
            : students.OrderBy(a => propInfo.GetValue(a, null));

        return sortedStudents.ToList();
    }
}
