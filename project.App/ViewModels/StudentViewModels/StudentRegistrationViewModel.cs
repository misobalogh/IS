using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using project.App.Services;
using project.App.Views.StudentViews;
using project.BL.Facades;
using project.BL.Facades.Interfaces;
using project.BL.Models;
using project.DAL.Enums;

namespace project.App.ViewModels;

public partial class StudentRegistrationViewModel(
    IActivityFacade activityFacade, 
    IEnrolledSubjectsFacade enrolledSubjectsFacade,
    IMessengerService messengerService,
    UserDataService userDataService) : StudentNavigationSideBar(messengerService, userDataService)
{

    public IEnumerable<ActivityListModel> Activities { get; set; } = null!;

    public string SubjectNameBtn { get; set; } = "Subject";
    public string ActivityNameBtn { get; set; } = "Activity";
    public string StartTimeBtn { get; set; } = "Start Time";
    public string CapacityBtn { get; set; } = "Capacity";

    private bool SortDescending = false;

    private SortBy SortedBy = SortBy.None;

    private enum SortBy
    {
        SubjectName,
        ActivityName,
        StartTime,
        Capacity,
        None
    };

    protected override async Task LoadDataAsync()
    {
        await base.LoadDataAsync();
        Activities = await activityFacade.GetAsync();
        var enrolledSubjects = await enrolledSubjectsFacade.GetAsync();

        if (loggedUser != null)
        {
            enrolledSubjects = enrolledSubjects.Where(subject => subject.StudentId == loggedUser.Id);
            List<Guid> EnrolledSubjecsIds = enrolledSubjects.Select(subject => subject.SubjectId).ToList();

            Activities = Activities.Where(activity =>
                (activity.ActivityType != ActivityType.MidtermExam && activity.ActivityType != ActivityType.FinalExam)
                && EnrolledSubjecsIds.Contains(activity.SubjectId));
        }
        SortBySubjectName();
    }

    [RelayCommand]
    async Task Register(ActivityModel activity)
    {
    }


    [RelayCommand]
    void SortBySubjectName()
    {
        ResetToOriginalName();

        ChangeSortDirectionIfSorted(SortBy.SubjectName);

        SubjectNameBtn = GetSortColName(SubjectNameBtn);

        Activities = activityFacade.GetSortedActivities(Activities, nameof(ActivityListModel.SubjectName), SortDescending);

        SortedBy = SortBy.SubjectName;
    }

    [RelayCommand]
    void SortByActivityName()
    {
        ResetToOriginalName();

        ChangeSortDirectionIfSorted(SortBy.ActivityName);

        ActivityNameBtn = GetSortColName(ActivityNameBtn);

        Activities = activityFacade.GetSortedActivities(Activities, nameof(ActivityListModel.Name), SortDescending);

        SortedBy = SortBy.ActivityName;
    }


    [RelayCommand]
    void SortByStartTime()
    {
        ResetToOriginalName();

        ChangeSortDirectionIfSorted(SortBy.StartTime);

        StartTimeBtn = GetSortColName(StartTimeBtn);

        Activities = activityFacade.GetSortedActivities(Activities, nameof(ActivityListModel.Start), SortDescending);

        SortedBy = SortBy.StartTime;
    }

    [RelayCommand]
    void SortByCapacity()
    {
        ResetToOriginalName();

        ChangeSortDirectionIfSorted(SortBy.Capacity);

        CapacityBtn = GetSortColName(CapacityBtn);

        Activities = activityFacade.GetSortedActivities(Activities, nameof(ActivityListModel.Capacity), SortDescending);

        SortedBy = SortBy.Capacity;
    }

    /// <summary>
    /// Sets column header to original text - without arrows
    /// </summary>
    private void ResetToOriginalName()
    {
        SubjectNameBtn = "Subject";
        ActivityNameBtn = "Activity";
        StartTimeBtn = "Start Time";
        CapacityBtn = "Capacity";
    }

    /// <summary>
    /// if clicked on column by which is already sorted -> change direction of sort
    /// </summary>
    private void ChangeSortDirectionIfSorted(SortBy newSortBy)
    {
        if (newSortBy == SortedBy)
        {
            SortDescending = !SortDescending;
        }
        else // if switched to sorting by different column, set to descending
        {
            SortDescending = false;
        }
    }

    private string GetSortColName(string colName)
    {
        if (SortDescending)
        {
            return colName + " ↓";
        }
        else
        {
            return colName + " ↑";
        }
    }
}

