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

    //[RelayCommand]
    //async Task NewActivity(object clickedItem)
    //{
    //    var route = $"{nameof(TeacherNewActivityView)}?subjectId={SubjectId}";
    //    await Shell.Current.GoToAsync(route);
    //}

    //[RelayCommand]
    //async Task EditActivity(object clickedItem)
    //{
    //    if (clickedItem == null)
    //    {
    //        await Shell.Current.GoToAsync($"{nameof(TeacherNewActivityView)}?subjectId={SubjectId}"); // TODO: předat SubjectName přes activity
    //        return; // v tomto případě se nejedná o editaci, ale o vytvoření nové aktivity, takže není id aktivity, ale víme jen název předmětu, respektive jeho Id
    //    }

    //    if (clickedItem is ActivityListModel activity) // TODO: sem se to asi nikdy nedostane, zachytí to funkce OnItemTapped v .xaml.cs
    //    {
    //        var route = $"{nameof(TeacherNewActivityView)}?activityId={activity.Id}";
    //        await Shell.Current.GoToAsync(route);
    //    }
    //}


    //[RelayCommand]
    //async Task EditActivity(object clickedItem)
    //{
    //    if (clickedItem == null)
    //    {
    //        return;
    //    }

    //    if (clickedItem is ActivityListModel activity)
    //    {
    //        // TODO: implement edit activity
    //        //var route = $"{nameof(TeacherEditActivityView)}?activityId={activity.Id}";
    //        //await Shell.Current.GoToAsync(route);
    //    }
    //}
}

