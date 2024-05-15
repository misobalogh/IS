﻿using project.BL.Mappers;
using project.BL.Models;
using project.DAL.Entities;
using project.DAL.Mappers;
using project.DAL.Repositories;
using project.DAL.UnitOfWork;

namespace project.BL.Facades;

public class EnrolledSubjectsFacade(IUnitOfWorkFactory unitOfWorkFactory, EnrolledSubjectsModelMapper enrolledSubjectsModelMapper)
    : FacadeBase<EnrolledSubjectEntity, EnrolledSubjectsListModel, EnrolledSubjectsModel, EnrolledSubjectEntityMapper>(unitOfWorkFactory, enrolledSubjectsModelMapper), IEnrolledSubjectsFacade
{

    protected override List<string> IncludesNavigationPathDetail =>
        [$"{nameof(EnrolledSubjectEntity.Student)}.{nameof(StudentEntity.EnrolledSubjects)}",
            $"{nameof(EnrolledSubjectEntity.Subject)}"];

    public async Task SaveAsync(EnrolledSubjectsModel model, Guid studentId)
    {
        EnrolledSubjectEntity entity = enrolledSubjectsModelMapper.MapToEntity(model, studentId);

        await using IUnitOfWork unitOfWork = UnitOfWorkFactory.Create();
        IRepository<EnrolledSubjectEntity> repository =
            unitOfWork.GetRepository<EnrolledSubjectEntity, EnrolledSubjectEntityMapper>();

        if (await repository.ExistsAsync(entity))
        {
            await repository.UpdateAsync(entity);
            await unitOfWork.CommitAsync();
        }
    }

    public async Task<List<EnrolledSubjectsListModel>> SearchSubject(string searchTerm)
    {
        await using IUnitOfWork unitOfWork = UnitOfWorkFactory.Create();
        IRepository<EnrolledSubjectEntity> repository =
            unitOfWork.GetRepository<EnrolledSubjectEntity, EnrolledSubjectEntityMapper>();

        IQueryable<EnrolledSubjectEntity> query = repository.Get()
            .Where(entity => entity.Subject.Tag.ToLower().Contains(searchTerm.ToLower()) ||
                entity.Subject.Name.ToLower().Contains(searchTerm.ToLower()));

        return query.AsEnumerable().Select(enrolledSubjectsModelMapper.MapToListModel).ToList();
    }
}
