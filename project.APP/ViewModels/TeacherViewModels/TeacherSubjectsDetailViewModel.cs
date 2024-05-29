using System.Collections.ObjectModel;
using System.Globalization;
using CommunityToolkit.Mvvm.Input;
using project.App.Services;
using project.App.Views.TeacherViews;
using project.BL.Facades;
using project.BL.Facades.Interfaces;
using project.BL.Models;
using project.DAL.Enums;

namespace project.App.ViewModels;

[QueryProperty("SubjectId", "subjectId")]
public partial class TeacherSubjectsDetailViewModel(
    ISubjectFacade subjectFacade,
    IActivityFacade activityFacade,
    IMessengerService messengerService,
    UserDataService userDataService) : TeacherNavigationSideBar(messengerService, userDataService)
{
    public string? SubjectId { get; set; }

    public SubjectModel? Subject { get; private set; }
    public IEnumerable<ActivityListModel> Activities { get; private set; } = null!;
    private DateTime _startDate;
    public DateTime StartDate
    {
        get => _startDate;
        set
        {
            SetProperty(ref _startDate, value);
            FilterActivities();
        }
    }

    private DateTime _endDate;
    public DateTime EndDate
    {
        get => _endDate;
        set
        {
            SetProperty(ref _endDate, value);
            FilterActivities();
        }
    }

    protected override async Task LoadDataAsync()
    {
        if (SubjectId == null)
        {
            return;
        }

        await base.LoadDataAsync();
        Subject = await subjectFacade.GetAsync(Guid.Parse(SubjectId));
        var activitiesList = await activityFacade.GetAsync();

        if (Subject != null)
        {
            activitiesList = activitiesList.Where(activity => activity.SubjectId == Subject.Id);
        }

        var sortedActivities = activityFacade.GetSortedActivities(activitiesList, nameof(ActivityListModel.ActivityType));
        Activities = new ObservableCollection<ActivityListModel>(sortedActivities);
    }

    private async void FilterActivities()
    {
        if (SubjectId == null)
        {
            return;
        }

        var activitiesList = await activityFacade.GetAsync();
        var filteredActivities = await activityFacade.FilterBySubjectsAsync(activitiesList, Guid.Parse(SubjectId), StartDate, EndDate);
        Activities = new ObservableCollection<ActivityListModel>(filteredActivities);
    }

    [RelayCommand]
    public async Task EditActivity(ActivityListModel clickedItem)
    {
        if (clickedItem == null)
        {
            await Shell.Current.GoToAsync($"{nameof(TeacherNewActivityView)}?subjectId={SubjectId}");
            return;
        }

        var route = $"{nameof(TeacherNewActivityView)}?activityId={clickedItem.Id}";
        await Shell.Current.GoToAsync(route);
    }
}

