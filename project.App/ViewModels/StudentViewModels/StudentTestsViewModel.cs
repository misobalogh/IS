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
    IRegisteredActivitiesFacade registeredActivitiesFacade,
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

    public async Task Register(ActivityListModel? activity)
    {
        if (activity != null && loggedUser != null)
        {

            var newRegisteredActivity = new RegisteredActivitiesModel()
            {
                ActivityId = activity.Id,
                Start = activity.Start,
                End = activity.End,
                ActivityName = activity.Name,
                Room = activity.Room
            };

            await registeredActivitiesFacade.SaveAsync(newRegisteredActivity, loggedUser.Id);
        }
    }

    public async Task Unregister(Guid? activityId)
    {
        if (activityId != null)
        {
            await registeredActivitiesFacade.DeleteAsync((Guid)activityId);
        }
    }

    public async Task<bool> IsRegistered(ActivityListModel? activity)
    {
        if (activity != null && loggedUser != null)
        {
            var registeredActivities = await registeredActivitiesFacade.GetAsync();

            registeredActivities = registeredActivities.Where(x => x.ActivityId == activity.Id && x.StudentId == loggedUser.Id);

            return registeredActivities.Any();
        }
        return false;
    }
}

