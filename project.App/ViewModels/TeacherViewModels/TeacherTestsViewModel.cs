using System.Collections.ObjectModel;
using System.Diagnostics;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using project.App.Services;
using project.App.Views.StudentViews;
using project.App.Views.TeacherViews;
using project.BL.Facades;
using project.BL.Facades.Interfaces;
using project.BL.Models;
using project.DAL.Enums;

namespace project.App.ViewModels;

public partial class TeacherTestsViewModel(
    IActivityFacade activityFacade, 
    IMessengerService messengerService,
    IEnrolledSubjectsFacade enrolledSubjectsFacade,
    UserDataService userDataService) : TeacherNavigationSideBar(messengerService, userDataService)
{
    public IEnumerable<EnrolledSubjectsListModel> EnrolledSubjects { get; private set; }
    
    private bool FirstSearch = true;

    public string TestNameBtn { get; set; } = "Name";

    private bool SortDescending = false;

    private SortBy SortedBy = SortBy.Name;

    private IEnumerable<ActivityListModel> activities;
    public IEnumerable<ActivityListModel> Activities
    {
        get => activities;
        set => SetProperty(ref activities, value);
    }

    private enum SortBy
    {
        Name,
        None
    }

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
                && loggedUser.LastName == activity.TeacherName);
        }
        SortByName();
    }

    [RelayCommand]
    public async Task ShowActivityDetails(ActivityListModel clickedItem)
    {
        if (clickedItem == null)
        {
            Debug.WriteLine("Clicked item is null");
            return;
        }

        Debug.WriteLine($"Clicked item: {clickedItem.SubjectName}, {clickedItem.Name}, {clickedItem.ActivityType}");
        var route = $"TeacherTestsDetailView?activityId={clickedItem.Id}";
        Debug.WriteLine($"Navigating to: {route}");
        try
        {
            await Shell.Current.GoToAsync(route);
        }
        catch (Exception ex)
        {
            Debug.WriteLine($"Navigation failed: {ex.Message}");
        }
    }


    [RelayCommand]
    void SortByName()
    {
        ResetToOriginalName();

        ChangeSortDirectionIfSorted(SortBy.Name);

        TestNameBtn = GetSortColName(TestNameBtn);

        Activities = activityFacade.GetSortedActivities(Activities, nameof(ActivityListModel.ActivityType), SortDescending);

        SortedBy = SortBy.Name;
    }

    /// <summary>
    /// Sets column header to original text - without arrows
    /// </summary>
    private void ResetToOriginalName()
    {
        TestNameBtn = "Name";
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

