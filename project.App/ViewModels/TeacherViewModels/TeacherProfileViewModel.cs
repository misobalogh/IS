using System.Windows.Input;
using CommunityToolkit.Mvvm.Input;
using project.App.Services;
using project.App.Views.StudentViews;
using project.App.Views.TeacherViews;
using project.BL.Facades;
using project.BL.Models;

namespace project.App.ViewModels;

public partial class TeacherProfileViewModel(IMessengerService messengerService, UserDataService userDataService, ITeacherFacade teacherFacade) : TeacherNavigationSideBar(messengerService, userDataService)
{
    public TeacherModel? Teacher { get; set; } = null!;
    public ICommand ChangeImageCommand { get; set; }


    protected override async Task LoadDataAsync()
    {
        await base.LoadDataAsync();
        if (loggedUser != null)
        {
            Teacher = await teacherFacade.GetAsync(loggedUser.Id);
        }

        ChangeImageCommand = new Command(OnChangeImage);
    }

    private async void OnChangeImage()
    {
        string newImageUrl = await Application.Current.MainPage.DisplayPromptAsync("Change Image", "Enter the URL of the new profile image:");

        if (!string.IsNullOrEmpty(newImageUrl))
        {
            loggedUser.PhotoUrl = new Uri(newImageUrl);

            var updatedStudent = await teacherFacade.SaveAsync(loggedUser);
            if (updatedStudent != null)
            {
                await Application.Current.MainPage.DisplayAlert("Success", "Profile image updated successfully.", "OK");
            }
            else
            {
                await Application.Current.MainPage.DisplayAlert("Error", "Failed to update profile image.", "OK");
            }
        }
    }
}
