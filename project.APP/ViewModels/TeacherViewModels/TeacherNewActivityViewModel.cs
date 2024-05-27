using CommunityToolkit.Mvvm.Input;
using project.App.Services;
using project.App.Views.TeacherViews;
using project.BL.Facades;
using project.BL.Facades.Interfaces;
using project.BL.Models;
using project.DAL.Enums;

namespace project.App.ViewModels;

[QueryProperty("SubjectId", "subjectId")]
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
    public string? SubjectId { get; set; }
    public SubjectModel? Subject { get; private set; }

    protected override async Task LoadDataAsync()
    {
        if (SubjectId == null)
        {
            return;
        }

        await base.LoadDataAsync();
        Subject = await subjectFacade.GetAsync(Guid.Parse(SubjectId));
    }

    [RelayCommand]
    async Task CreateActivity()
    {
        if (string.IsNullOrEmpty(NewActivity.Name)/* ||*/
            //string.IsNullOrEmpty(NewActivity.Start) ||
            /*string.IsNullOrEmpty(NewActivity.Capacity)*/)
        {
            NotifyUser("Please fill in all required fields: Name of the activity..."); // TODO: add more fields
            return;
        }

        //if (!NewActivity.Email.Contains('@'))
        //{
        //    NotifyUser("Invalid email");
        //    return;
        //}

        // Check if email is unique
        //bool emailExists = await teacherFacade.EmailExistsAsync(NewTeacher.Email);
        //if (emailExists)
        //{
        //    NotifyUser("Email already exists.");
        //    return;
        //}

        await activityFacade.SaveAsync(NewActivity, Guid.Parse(SubjectId), loggedUser.Id);
        NotifyUser("New activity successfully created");
        await LoadDataAsync();
        await Shell.Current.GoToAsync(nameof(TeacherSubjectsView));

    }

    private static void NotifyUser(string message)
    {
        MainThread.BeginInvokeOnMainThread(() =>
        {
            Shell.Current.DisplayAlert("Notification", message, "OK");
        });
    }
}
