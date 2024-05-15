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

public partial class StudentTestsViewModel(
    IActivityFacade activityFacade,
    IEnrolledSubjectsFacade enrolledSubjectsFacade,
    IMessengerService messengerService,
    UserDataService userDataService) : StudentNavigationSideBar(messengerService, userDataService)
{    
    public IEnumerable<ActivityListModel> Activities { get; private set; } = null!;
    public IEnumerable<EnrolledSubjectsListModel> EnrolledSubjects { get; private set; } = null!;

    protected override async Task LoadDataAsync()
    {
        await base.LoadDataAsync();
        Activities = await activityFacade.GetAsync();
        EnrolledSubjects = await enrolledSubjectsFacade.GetAsync();

        if (loggedUser != null)
        {
            EnrolledSubjects = EnrolledSubjects.Where(subject => subject.StudentId == loggedUser.Id);
            List<Guid> EnrolledSubjecsIds = EnrolledSubjects.Select(subject => subject.SubjectId).ToList();
            
            Activities = Activities.Where(activity =>
                (activity.ActivityType == ActivityType.MidtermExam || activity.ActivityType == ActivityType.FinalExam) 
                && EnrolledSubjecsIds.Contains(activity.SubjectId));
        }
    }
}

