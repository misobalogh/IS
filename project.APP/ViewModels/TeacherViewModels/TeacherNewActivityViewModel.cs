using CommunityToolkit.Mvvm.Input;
using project.App.Services;
using project.App.Views.TeacherViews;
using project.BL.Facades;
using project.BL.Facades.Interfaces;
using project.BL.Models;
using project.DAL.Enums;

namespace project.App.ViewModels;

public partial class TeacherNewActivityViewModel(
    IActivityFacade activityFacade,
    IMessengerService messengerService, 
    UserDataService userDataService)
    : TeacherNavigationSideBar(messengerService, userDataService)
{
    public ActivityModel NewActivity { get; private set; } = ActivityModel.Empty;

    [RelayCommand]
    async Task CreateActivity()
    {
        if (string.IsNullOrEmpty(NewActivity.Name)/* ||*/
            //string.IsNullOrEmpty(NewActivity.Start) ||
            /*string.IsNullOrEmpty(NewActivity.Capacity)*/)
        {
            NotifyUser("Please fill in all required fields: Name..."); // TODO: add more fields
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

        await activityFacade.SaveAsync(NewActivity);
        NotifyUser("New activity successfully created");
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
