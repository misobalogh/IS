﻿using project.BL.Facades.Interfaces;
using project.BL.Models;
using project.DAL.Entities;

namespace project.BL.Facades;

public interface ISubjectFacade : IFacade<SubjectEntity, SubjectListModel, SubjectModel>
{
    Task<List<SubjectListModel>> SearchSubject(string searchTerm);
    IEnumerable<SubjectListModel> Sort(IEnumerable<SubjectListModel> subjects, string sortBy, bool descending);
}
