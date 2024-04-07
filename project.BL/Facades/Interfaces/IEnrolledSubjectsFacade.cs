﻿using project.BL.Models;
using project.DAL.Entities;

namespace project.BL.Facades;

public interface IEnrolledSubjectsFacade : IFacade<EnrolledSubjectEntity, EnrolledSubjectsListModel, EnrolledSubjectsModel>
{
    Task SaveAsync(EnrolledSubjectsModel model, Guid studentId);
}
