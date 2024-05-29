using System.Reflection;
using Microsoft.EntityFrameworkCore;
using project.BL.Mappers;
using project.BL.Models;
using project.DAL.Entities;
using project.DAL.Mappers;
using project.DAL.Repositories;
using project.DAL.UnitOfWork;

namespace project.BL.Facades;

public class TeacherFacade(IUnitOfWorkFactory unitOfWorkFactory, TeacherModelMapper teacherModelMapper) 
    : FacadeBase<TeacherEntity, TeacherListModel, TeacherModel, TeacherEntityMapper>(unitOfWorkFactory, teacherModelMapper), ITeacherFacade
{
    protected override List<string> IncludesNavigationPathDetail =>
        [$"{nameof(TeacherEntity.Subjects)}.{nameof(TeachingSubjectsEntity.Subject)}"];


    public async Task<List<TeacherListModel>> SearchTeacher(string searchTerm)
    {
        await using IUnitOfWork unitOfWork = UnitOfWorkFactory.Create();
        var repository = unitOfWork.GetRepository<TeacherEntity, TeacherEntityMapper>();

        IQueryable<TeacherEntity> query = repository.Get();

        foreach (var include in IncludesNavigationPathDetail)
        {
            query = query.Include(include); 
        }

        query = query.Where(entity => entity.FirstName.ToLower().Contains(searchTerm.ToLower()) || entity.LastName.ToLower().Contains(searchTerm.ToLower()));

        return query.Select(teacherModelMapper.MapToListModel).ToList();
    }

    public async Task<bool> EmailExistsAsync(string email)
    {
        await using IUnitOfWork unitOfWork = UnitOfWorkFactory.Create();
        var repository = unitOfWork.GetRepository<TeacherEntity, TeacherEntityMapper>();

        return await repository.Get().AnyAsync(entity => entity.Email == email);
    }

    public IEnumerable<TeacherListModel> Sort(IEnumerable<TeacherListModel> teachers, string sortBy, bool descending)
    {
        PropertyInfo? propInfo = typeof(TeacherListModel).GetProperty(sortBy);
        if (propInfo == null)
        {
            throw new ArgumentException($"'{sortBy}' is not a valid property of TeacherListModel");
        }

        var sorted = descending
            ? teachers.OrderByDescending(a => propInfo.GetValue(a, null))
            : teachers.OrderBy(a => propInfo.GetValue(a, null));

        return sorted.ToList();
    }
}
