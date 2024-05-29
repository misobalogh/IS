using CommunityToolkit.Mvvm.Input;
using project.App.Services;
using project.App.Views.TeacherViews;
using project.BL.Facades;
using project.BL.Facades.Interfaces;
using project.BL.Models;
using project.DAL.Enums;

namespace project.App.ViewModels;

[QueryProperty(nameof(ActivityId), "activityId")]
[QueryProperty(nameof(SubjectId), "subjectId")]
public partial class TeacherNewActivityViewModel(
    IActivityFacade activityFacade,
    ISubjectFacade subjectFacade,
    IMessengerService messengerService, 
    UserDataService userDataService)
    : TeacherNavigationSideBar(messengerService, userDataService)
{
    public ActivityModel NewActivity { get; private set; } = ActivityModel.Empty;
    public List<Room> Rooms { get; private set; } = Enum.GetValues(typeof(Room)).Cast<Room>().ToList();
    public List<ActivityType> ActivityTypes { get; private set; } = Enum.GetValues(typeof(ActivityType)).Cast<ActivityType>().ToList();
    public string? ActivityId { get; set; }
    public string? SubjectId { get; set; }
    public ActivityModel? Activity { get; private set; }

    protected override async Task LoadDataAsync()
    {
        if (string.IsNullOrEmpty(ActivityId))
        {
            return;
        }

        await base.LoadDataAsync();
        if (!string.IsNullOrEmpty(ActivityId))
        {
            Activity = await activityFacade.GetAsync(Guid.Parse(ActivityId)) ?? ActivityModel.Empty;
        }
        else if (!string.IsNullOrEmpty(SubjectId))
        {
            var subject = await subjectFacade.GetAsync(Guid.Parse(SubjectId));
            if (subject != null)
            {
                NewActivity.SubjectId = subject.Id;
                NewActivity.SubjectName = subject.Name;
            }
        }
    }

    [RelayCommand]
    async Task CreateActivity()
    {
        if (string.IsNullOrEmpty(NewActivity.Name))
        {
            NotifyUser("Please fill in all required fields: Name of the activity..."); // TODO: add more fields
            return;
        }

        if (ActivityId == null || loggedUser == null)
        {
            NotifyUser("There was problem with create activity");
            return;
        };

        await activityFacade.SaveAsync(NewActivity, Guid.Parse(ActivityId), loggedUser.Id);
        NotifyUser("New activity successfully created");
        //await LoadDataAsync();
        await Shell.Current.GoToAsync(nameof(TeacherSubjectsView));
    }

    //[RelayCommand]
    //async Task DeleteActivity()
    //{
    //    if (string.IsNullOrEmpty(SubjectId))
    //    {
    //        NotifyUser("Subject not found");
    //        return;
    //    }

    //    await subjectFacade.DeleteAsync(Guid.Parse(SubjectId));
    //    NotifyUser("Subject successfully deleted");
    //    await Shell.Current.GoToAsync(nameof(AdminSubjectsView));
    //}

    private static void NotifyUser(string message)
    {
        MainThread.BeginInvokeOnMainThread(() =>
        {
            Shell.Current.DisplayAlert("Notification", message, "OK");
        });
    }
}
