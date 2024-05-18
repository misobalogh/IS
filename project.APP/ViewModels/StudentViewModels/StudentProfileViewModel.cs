using System.Windows.Input;
using project.App.Services;
using project.BL.Facades;
using project.BL.Models;

namespace project.App.ViewModels;

public partial class StudentProfileViewModel(
    ISubjectFacade subjectFacade, 
    IStudentFacade studentFacade, 
    IMessengerService messengerService,
    UserDataService userDataService) : StudentNavigationSideBar(messengerService, userDataService)
{

    public StudentModel Students { get; set; } = null!;
    public IEnumerable<SubjectListModel> Subjects { get; set; } = null!;
    public ICommand ChangeImageCommand { get; set; }


    protected override async Task LoadDataAsync()
    {
        await base.LoadDataAsync();

        if (loggedUser != null) { 
            Students = await studentFacade.GetAsync(loggedUser.Id);
        }
        Subjects = await subjectFacade.GetAsync();
        ChangeImageCommand = new Command(OnChangeImage);
    }

    private async void OnChangeImage()
    {
        string newImageUrl = await Application.Current.MainPage.DisplayPromptAsync("Change Image", "Enter the URL of the new profile image:");

        if (!string.IsNullOrEmpty(newImageUrl))
        {
            loggedUser.Image = new Uri(newImageUrl);

            var updatedStudent = await studentFacade.SaveAsync(loggedUser);
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
