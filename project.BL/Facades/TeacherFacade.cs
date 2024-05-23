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
    public async Task SaveAsync(TeacherModel model)
    {
        TeacherEntity entity = teacherModelMapper.MapToEntity(model);

        await using IUnitOfWork unitOfWork = UnitOfWorkFactory.Create();
        IRepository<TeacherEntity> repository =
            unitOfWork.GetRepository<TeacherEntity, TeacherEntityMapper>();

        if (await repository.ExistsAsync(entity))
        {
            await repository.UpdateAsync(entity);
            await unitOfWork.CommitAsync();
        }
    }

    public async Task<List<TeacherListModel>> SearchTeacher(string searchTerm)
    {
        await using IUnitOfWork unitOfWork = UnitOfWorkFactory.Create();
        var repository = unitOfWork.GetRepository<TeacherEntity, TeacherEntityMapper>();

        IQueryable<TeacherEntity> query = repository.Get()
            .Where(entity => entity.FirstName.ToLower().Contains(searchTerm.ToLower()) || entity.LastName.ToLower().Contains(searchTerm.ToLower()));

        return query.AsEnumerable().Select(teacherModelMapper.MapToListModel).ToList();
    }

    public async Task<bool> EmailExistsAsync(string email)
    {
        await using IUnitOfWork unitOfWork = UnitOfWorkFactory.Create();
        var repository = unitOfWork.GetRepository<TeacherEntity, TeacherEntityMapper>();


        IQueryable<TeacherEntity> query = repository.Get().Where(entity => entity.Email == email);
        return query.AsEnumerable().Any();
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
