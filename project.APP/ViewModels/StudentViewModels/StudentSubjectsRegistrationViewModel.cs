using System.Collections.ObjectModel;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using project.App.Services;
using project.App.Views.StudentViews;
using project.BL.Facades;
using project.BL.Facades.Interfaces;
using project.BL.Models;
using project.DAL.Enums;

namespace project.App.ViewModels;

public partial class StudentSubjectsRegistrationViewModel(
    ISubjectFacade subjectFacade,
    IEnrolledSubjectsFacade enrolledSubjectsFacade,
    IMessengerService messengerService,
    UserDataService userDataService) : StudentNavigationSideBar(messengerService, userDataService)
{

    public IEnumerable<SubjectListModel> Subjects { get; set; } = null!;

    protected override async Task LoadDataAsync()
    {
        await base.LoadDataAsync();
        Subjects = await subjectFacade.GetAsync();
    }

    public async Task Register(SubjectListModel? subject)
    {
        if (subject != null && loggedUser != null)
        {

            var newEnrolledSubject = new EnrolledSubjectsModel()
            {
                Mark = Mark.None,
                SubjectName = subject.SubjectName,
                Points = 0,
                SubjectId = subject.Id,
                StudentId = loggedUser.Id,
                Year = DateTime.Now,
            };

            await enrolledSubjectsFacade.SaveAsync(newEnrolledSubject, loggedUser.Id);
        }
    }

    public async Task Unregister(Guid? subjectId)
    {
        if (subjectId != null)
        {
            await enrolledSubjectsFacade.DeleteAsync((Guid)subjectId);
        }
    }

    public async Task<bool> IsRegistered(SubjectListModel? subject)
    {
        if (subject != null && loggedUser != null)
        {
            var enrolledSubjects = await enrolledSubjectsFacade.GetAsync();

            enrolledSubjects = enrolledSubjects.Where(x => x.SubjectId == subject.Id && x.StudentId == loggedUser.Id);

            return enrolledSubjects.Any();
        }
        return false;
    }
}

